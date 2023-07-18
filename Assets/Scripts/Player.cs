using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int hp;
    private int mp;
    public int maxHP = 10;
    public int maxMP = 10;

    public static Player Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HP = maxHP;
        MP = 0;
    }
    private void Update()
    {
        if(HP<=0)
        {
            Time.timeScale = 0;
        }
    }
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
                //Debug.Log("??????????");
            }
            hp = value;
            UI_Manager.Instance.SetUI_HP(hp, maxHP);
            if (hp <= 0)
            {
                UI_Manager.Instance.GameOverImage.SetActive(true);
            }
            if (hp > maxHP)
            {
                hp = maxHP;
            }
        }
    }

    public int MP
    {
        get
        {
            return mp;
        }
        set
        {
            if (value < mp)
            {
                // ?????????? ?????? ???? ?? 
            }
            mp = value;
            UI_Manager.Instance.SetUI_MP(mp, maxMP);
            if (mp <= 0)
            {
                
            }
            if (mp > maxMP)
            {
                mp = maxMP;
            }
        }
    }
}
