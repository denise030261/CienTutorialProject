using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainScript : MonoBehaviour
{
    private int hp;
    public int maxHP = 5;
    public int Damage = 1;
    public float DamageReload = 3;
    public int MoveSpeed = 0;

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            if (value < hp)
            {

            }
            hp = value;
            if (hp > maxHP)
            {
                hp = maxHP;
            }
        }
    }

    private void Start()
    {
        StartCoroutine(DamageRoutine());
        HP = maxHP;
    }

    IEnumerator DamageRoutine()
    {
        yield return new WaitForSeconds(DamageReload);
        Player.Instance.HP -= Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Áö³ª°©´Ï´Ù");
        if (collision.gameObject.tag == "Dish")
        {
            hp -= 1;

            if (hp <= 0)
            {
                Destroy(gameObject);
                Player.Instance.MP += 2;
            }
        }
    }
}
