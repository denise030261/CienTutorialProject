using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScript : Enemy
{
    public float cleanerCooldown = 1f;
    private float timer = 0f;
    public float speed = 1f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        SetHpMax();

        timer = cleanerCooldown;
        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOutrange())
        {
            direction = Random.insideUnitCircle.normalized;
        }

        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Cleaner"))
        {
            if (timer <= 0f)
            {
                timer = cleanerCooldown;

                hp -= 1;

                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
            }

            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = cleanerCooldown;
    }

    private bool IsOutrange()
    {
        return (transform.position.x < CameraScope.Instance.minX)
            || (transform.position.x > CameraScope.Instance.maxX)
            || (transform.position.y < CameraScope.Instance.minY)
            || (transform.position.y > CameraScope.Instance.maxY);
    }
}
