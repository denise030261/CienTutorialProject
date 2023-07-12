using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int hp;
    private int mp;
    public int maxHP = 5;
    public int maxMP = 10;

    public static Player Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
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
                // 플레이어가 데미지 입을 때 
            }
            hp = value;
            UI_Manager.Instance.SetUI_HP(hp, maxHP);
            if (hp <= 0)
            {
                // 게임 오버 화면 띄우기
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
                // 플레이어가 데미지 입을 때 
            }
            mp = value;
            UI_Manager.Instance.SetUI_MP(mp, maxMP);
            if (mp <= 0)
            {
                UI_Manager.Instance.GameOverImage.SetActive(true);
            }
            if (mp > maxMP)
            {
                mp = maxMP;
            }
        }
    }
}
