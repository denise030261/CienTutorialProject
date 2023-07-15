using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_World : MonoBehaviour
{
    public int Score;
    public int Stage;
    public int Hp;
    public int Mp;

    public static GameManager_World Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
        Stage = PlayerPrefs.GetInt("Stage", 1);
        Hp = PlayerPrefs.GetInt("Hp", 0);
        Mp = PlayerPrefs.GetInt("Mp", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
