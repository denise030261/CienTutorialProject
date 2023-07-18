using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : Enemy
{
    private float turnInterval = 2f;
    private float timer;
    public float speed = 1f;
    private Vector2 direction;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Start is called before the first frame update
    void Start()
    {
        SetHpMax();

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
        if (collision.gameObject.name.Contains("Flapper"))
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
        return (transform.position.x > maxX)
            || (transform.position.x < minX)
            || (transform.position.y > maxY)
            || (transform.position.y < minY);
    }

    public void SetBound(float minX, float maxX, float minY, float maxY)
    {
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
    }
}
