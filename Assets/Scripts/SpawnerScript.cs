using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

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

            Vector3 position = new Vector3();
            position.x = Random.Range(-6, 6);
            position.y = Random.Range(-2, 2);
            Instantiate(enemy, position, Quaternion.identity);

            yield return new WaitForSeconds(10);
        }
    }
}
