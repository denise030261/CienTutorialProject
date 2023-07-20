using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float SpawnSpeed = 10f;
    private int step = 0; // 스폰 단계
    private int IntervalScore=2000;
    private int PreviousScore= 2500;

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
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0);
        
        while (enabled)
        {
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            if(Player.Instance.score<500 && step==0)
            {
                enemy = enemyPrefabs[0];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if(Player.Instance.score >= 500 && Player.Instance.score < 1000 && step == 0)
            {
                enemy = enemyPrefabs[1];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if (Player.Instance.score >= 1000 && Player.Instance.score < 2000 && step == 0)
            {
                enemy = enemyPrefabs[Random.Range(0, 1)];
                Debug.Log("PreviousScore : " + PreviousScore + "IntervalScore : " + IntervalScore);
            }
            else if (Player.Instance.score >= 2000 && Player.Instance.score < 2500 && step == 0)
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
            //라운드, 적의 HP, MP, Damage, Spawn을 조절
            float minX = CameraBound.Instance.Left + enemy.transform.localScale.x / 2;
            float maxX = CameraBound.Instance.Right - enemy.transform.localScale.x / 2;
            float minY = CameraBound.Instance.Bottom + enemy.transform.localScale.y / 2;
            float maxY = CameraBound.Instance.Top - enemy.transform.localScale.y / 2;

            Vector3 position = new Vector3();

            position.x = Random.Range(minX, maxX);
            position.y = Random.Range(minY, maxY);

            Instantiate(enemy, position, Quaternion.identity);

           yield return new WaitForSeconds(SpawnSpeed);
        }
    }
   
}
