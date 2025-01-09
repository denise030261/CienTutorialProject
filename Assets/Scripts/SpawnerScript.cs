using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float SpawnSpeed;
    private int step;
    private int IntervalScore;
    private int PreviousScore;

    public static SpawnerScript Instance { get; private set; } = null;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(Player.Instance.score > PreviousScore + IntervalScore)
        {
            if (step == 3)
            { 
                step = 1;
                Enemy.Instance.GiveScore += 50;
                Enemy.Instance.GiveMP += 10;
            }
            else if(step==0)
            {
                step++;
                Enemy.Instance.GiveScore += 50;
                Enemy.Instance.GiveMP += 10;
            }
            else
            {
                step++;
            }
            PreviousScore += IntervalScore;
        }
    }

    public void Init()
    {
        SpawnSpeed = 5f;
        step = 0;
        IntervalScore=1500;
        PreviousScore= 1500;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0);
        
        while (!GameManager_World.Instance.bPause)
        {
            Debug.Log("start");
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            if(Player.Instance.score<350 && step==0)
            {
                enemy = enemyPrefabs[0];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if(Player.Instance.score >= 350 && Player.Instance.score < 800 && step == 0)
            {
                enemy = enemyPrefabs[1];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if (Player.Instance.score >= 800 && Player.Instance.score < 1200 && step == 0)
            {
                enemy = enemyPrefabs[Random.Range(0, 1)];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if (Player.Instance.score >= 1200 && Player.Instance.score < 1500 && step == 0)
            {
                enemy = enemyPrefabs[2];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if(Player.Instance.score >= PreviousScore && Player.Instance.score < PreviousScore + IntervalScore && step == 0)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if (Player.Instance.score >= PreviousScore && Player.Instance.score < PreviousScore+IntervalScore && step == 1)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                if(SpawnSpeed==1)
                {
                    SpawnSpeed = 1;
                }
                else
                {
                    SpawnSpeed -= 0.2f;
                }
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore + "Step : " + step);
            }
            else if (Player.Instance.score >= PreviousScore && Player.Instance.score < PreviousScore + IntervalScore && step == 2)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Enemy.Instance.damage += 1;
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore + "Step : " + step);
            }
            else if (Player.Instance.score >= PreviousScore && Player.Instance.score < PreviousScore + IntervalScore && step == 3)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Enemy.Instance.maxHP += 2;
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore + "Step : " + step);
            }
            //??????, ???? HP, MP, Damage, Spawn?? ????

            //float minX = CameraBound.Instance.Left + enemy.transform.localScale.x / 2;
            //float maxX = CameraBound.Instance.Right - enemy.transform.localScale.x / 2;
            //float minY = CameraBound.Instance.Bottom + enemy.transform.localScale.y / 2;
            //float maxY = CameraBound.Instance.Top - enemy.transform.localScale.y / 2;

            float minX = CameraBound.Instance.Left + enemy.transform.localScale.x / 2;
            float maxX = CameraBound.Instance.Right - enemy.transform.localScale.x / 2;
            float minY = CameraBound.Instance.Bottom + 3;
            float maxY = CameraBound.Instance.Top - 3;

            Vector3 position = new Vector3();

            position.x = Random.Range(minX, maxX);
            position.y = Random.Range(minY, maxY);

            Instantiate(enemy, position, Quaternion.identity);

           yield return new WaitForSeconds(SpawnSpeed);
        }
    }
}
