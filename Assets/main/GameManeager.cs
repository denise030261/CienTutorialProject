using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private int currentStage = 1;
    private int score = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetStage(int stage)
    {
        currentStage = stage;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void ResetGame()
    {
        currentStage = 1;
        score = 0;
    }

    public int GetCurrentStage()
    {
        return currentStage;
    }

    public int GetScore()
    {
        return score;
    }
}
