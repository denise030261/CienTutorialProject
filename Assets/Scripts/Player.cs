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
    public int score = 0;

    private AudioSource audioSource;
    public AudioClip attackClips;

    [SerializeField]
    float skillTime = 3f;

    public static Player Instance { get; private set; } = null;

    public GameObject spawner;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Init();
    }

    private void Update()
    {
        if (MP == maxMP && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

            audioSource.clip = attackClips;
            audioSource.Play();

            StartCoroutine(UI_Manager.Instance.UI_Skill(skillTime));

            foreach (GameObject Enemy in Enemies)
            {
                MP = 0;
                Destroy(Enemy);
            }
        }
    }

    public void Init()
    {
        HP = maxHP;
        MP = 0;
        score = 0;
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
                spawner.SetActive(false);

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }

                UI_Manager.Instance.SetScore(score);
                GameManager_World.Instance.EndGame(true);
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
