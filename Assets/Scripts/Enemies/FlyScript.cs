using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : Enemy
{
    private float turnInterval = 2f;
    private float timer;
    public float speed = 1f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        timer = turnInterval;
        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0f || IsOutrange())
        {
            timer = turnInterval;

            direction = Random.insideUnitCircle.normalized;
        }

        transform.Translate(speed * Time.deltaTime * direction);

        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flapper"))
        {
            hp -= 1;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private bool IsOutrange()
    {
        return (transform.position.x >= transform.parent.position.x - 2f)
            && (transform.position.x <= transform.parent.position.x + 2f)
            && (transform.position.y >= transform.parent.position.y - 2f)
            && (transform.position.y <= transform.parent.position.y + 2f);
    }
}
