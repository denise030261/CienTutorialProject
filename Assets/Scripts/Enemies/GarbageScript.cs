using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageScript : Enemy
{
    public GameObject flyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetHpMax();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Hand"))
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
            
            float minX = Mathf.Max(CameraBound.Instance.Left, transform.position.x - 3) + flyPrefab.transform.localScale.x / 2;
            float maxX = Mathf.Min(CameraBound.Instance.Right, transform.position.x + 3) - flyPrefab.transform.localScale.x / 2;
            float minY = Mathf.Max(CameraBound.Instance.Bottom, transform.position.y - 3) + flyPrefab.transform.localScale.y / 2;
            float maxY = Mathf.Min(CameraBound.Instance.Top, transform.position.y + 3) - flyPrefab.transform.localScale.y / 2;

            Vector3 position = new Vector3();

            position.x = Random.Range(minX, maxX);
            position.y = Random.Range(minY, maxY);

            GameObject flyInstance = Instantiate(flyPrefab, position, Quaternion.identity);
            flyInstance.GetComponent<FlyScript>().SetBound(minX, maxX, minY, maxY);
        }
    }
}
