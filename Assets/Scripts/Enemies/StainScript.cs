using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainScript : Enemy
{
    private void Start()
    {
        SetHpMax();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dish")
        {
            hp -= 1;

            if (hp <= 0)
            {
                Destroy(gameObject);
                Player.Instance.score += GiveScore;
                Player.Instance.MP += GiveMP;
            }
        }
    }
}
