using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageScript : Enemy
{
    public GameObject flyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            hp -= 1;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnFly());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnFly()
    {
        yield return new WaitForSeconds(0);

        while (enabled)
        {
            yield return new WaitForSeconds(5f);

            Instantiate(flyPrefab, gameObject.transform);
        }
    }
}