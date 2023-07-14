using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Vector2 startPosition = transform.position;
        float x = Random.Range(-1, 1);
        float y = Random.Range(-1, 1);
        Vector2 targetPosition = new Vector2(startPosition.x + x, startPosition.y + y);
        transform.position = targetPosition;

        yield return new WaitForSeconds(2);
    }
}
