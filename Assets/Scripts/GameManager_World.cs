using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_World : MonoBehaviour
{
    public int Score;
    public int Stage;
    public int InitialHp;
    public int InitialMp;

    public static GameManager_World Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
        Stage = PlayerPrefs.GetInt("Stage", 1);
        InitialHp = PlayerPrefs.GetInt("Hp", 5);
        InitialMp = PlayerPrefs.GetInt("Mp", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
