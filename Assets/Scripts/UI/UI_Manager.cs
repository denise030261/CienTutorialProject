using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Image HP_Image;
    public Image MP_Image;
    public Text ScoreText;
    public Text highScoreText;
    public Text currentScoreText;

    public GameObject GameOverImage;
    public static UI_Manager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ScoreText.text = "Score : " + Player.Instance.score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc ?????? ??????????");
            // ???? ???? ?????? ????
        }
    }

    public void SetUI_HP(int current, int max)
    {
        HP_Image.fillAmount = (float)current / max;
    } // HP ????

    public void SetUI_MP(int current, int max)
    {
        MP_Image.fillAmount = (float)current / max;
    } // MP ????

    public void SetScore(int currentScore)
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore = currentScore;
        }

        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
        currentScoreText.text = "CURRENT SCORE: " + currentScore.ToString();
    }

    public void OnClick_Retry()
    {
        
    } // ???? ????

    public void OnClick_LoadToMain()
    {
        
    } // ????????????
}
