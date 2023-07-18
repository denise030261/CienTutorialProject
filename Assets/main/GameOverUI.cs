using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text stageText;
    public Text scoreText;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        int currentStage = GameManager.Instance.GetCurrentStage();
        int score = GameManager.Instance.GetScore();

        stageText.text = "Stage: " + currentStage.ToString();
        scoreText.text = "Score: " + score.ToString();
    }
}
