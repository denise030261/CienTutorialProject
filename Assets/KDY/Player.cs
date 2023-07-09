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

    public Image HP_Image;
    public Image MP_Image;

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
            SetUI_HP(hp, maxHP);
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
            SetUI_HP(mp, maxMP);
            if (mp <= 0)
            {
                // 게임 오버 화면 띄우기
            }
            if (mp > maxMP)
            {
                mp = maxMP;
            }
        }
    }
    private void SetUI_HP(int current, int max)
    {
        HP_Image.fillAmount = (float)current / max;
    }
    private void SetUI_MP(int current, int max)
    {
        MP_Image.fillAmount = (float)current / max;
    }
}
