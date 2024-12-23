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
    [SerializeField] Image EmotionImage;

    [Tooltip("0번째는 100퍼, 1번째는 50퍼, 2번째는 25, 3번째는 0")]
    [SerializeField] List<Sprite> EmotionImages = new List<Sprite>();

    public GameObject GameOverImage;
    public static UI_Manager Instance { get; private set; } = null;

    public GameObject spawner;

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
        if(HP_Image.fillAmount > 0.5f )
        {
            EmotionImage.sprite = EmotionImages[0];
        }
        else if(HP_Image.fillAmount > 0.25f)
        {
            EmotionImage.sprite = EmotionImages[1];
        }
        else if (HP_Image.fillAmount > 0f)
        {
            EmotionImage.sprite = EmotionImages[2];
        }
        else 
        {
            EmotionImage.sprite = EmotionImages[3];
        }
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
        Player.Instance.Init();
        spawner.GetComponent<SpawnerScript>().Init();
        spawner.SetActive(true);
        GameOverImage.SetActive(false);
    } // ???? ????

    public void OnClick_LoadToMain()
    {
        SceneManager.LoadScene("mainmenu");
    } // ????????????
}
