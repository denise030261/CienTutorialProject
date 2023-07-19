using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float SpawnSpeed = 10f;
    private int step = 0; // 스폰 단계
    private int IntervalScore=2000;
    private int PreviousScore;

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
            }
            else if(Player.Instance.score >= 500 && Player.Instance.score < 1000 && step == 0)
            {
                enemy = enemyPrefabs[1];
            }
            else if (Player.Instance.score >= 1000 && Player.Instance.score < 2000 && step == 0)
            {
                enemy = enemyPrefabs[Random.Range(0, 1)];
            }
            else if (Player.Instance.score >= 2000 && Player.Instance.score < 2500 && step == 0)
            {
                enemy = enemyPrefabs[2];
            }
            else if(Player.Instance.score >= 2500 && Player.Instance.score < 3500 && step == 0)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                PreviousScore = 3500;
            }
            else if (Player.Instance.score >= PreviousScore && Player.Instance.score < PreviousScore+IntervalScore && step == 0)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            }
            else if (Player.Instance.score >= 2500 && Player.Instance.score < 3500 && step == 2)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            }
            else if (Player.Instance.score >= 2500 && Player.Instance.score < 3500 && step == 3)
            {
                enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
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
