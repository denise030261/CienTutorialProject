using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStain : MonoBehaviour
{
    public GameObject objectPrefab;
    public float minX = -1f;
    public float maxX = 1f;
    public float minY = -1f;
    public float maxY = 1f;
    public float spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(transform.position.x+randomX, transform.position.y + randomY, transform.position.z);
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
