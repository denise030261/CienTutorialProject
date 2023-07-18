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

            float minX = CameraBound.Instance.Left + enemy.transform.localScale.x / 2;
            float maxX = CameraBound.Instance.Right - enemy.transform.localScale.x / 2;
            float minY = CameraBound.Instance.Top - enemy.transform.localScale.y / 2;
            float maxY = CameraBound.Instance.Bottom + enemy.transform.localScale.y / 2;

            Vector3 position = new Vector3();
            position.x = Random.Range(minX, maxX);
            position.y = Random.Range(minY, maxY);
            Instantiate(enemy, position, Quaternion.identity);

            yield return new WaitForSeconds(10);
        }
    }
}
