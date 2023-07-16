using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hp;
    public int maxHP = 5;
    public int Damage = 1;
    public float DamageReload = 3;
    public int MoveSpeed = 0;
    public int Score;

    public static Enemy Instance { get; private set; } = null;

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
                // ���� ������ ���� �� 
            }
            hp = value;
            if (hp > maxHP)
            {
                hp = maxHP;
            }
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(DamageRoutine());
    }

    IEnumerator DamageRoutine()
    {
        yield return new WaitForSeconds(DamageReload);
        Debug.Log("Ȯ��");
        Player.Instance.HP -= Damage;
    }
}
