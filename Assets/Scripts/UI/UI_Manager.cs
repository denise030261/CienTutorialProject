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

    [Header("Space Animation")]
    [SerializeField]
    Animator spaceAnimator;
    [SerializeField]
    GameObject spaceObject;

    [Space(30)]
    [Header("Skill Animation")]
    [SerializeField]
    Animator skillAnimator;
    [SerializeField]
    GameObject skillObject;

    [Space(30)]
    [Header("Warning Animation")]
    [SerializeField]
    Animator warningAnimator;
    [SerializeField]
    GameObject warningObject;

    [Space(30)]
    public GameObject GameOverImage;

    [Space(30)]
    [SerializeField] private GameObject recordObject;
    [SerializeField] Button recordButton;
    public static UI_Manager Instance { get; private set; } = null;

    public GameObject spawner;
    private int score = 0;
    [SerializeField] RankData rankData;
    [SerializeField] InputField inputField;

    private void Awake()
    {
        Instance = this;
        spaceAnimator.enabled = false;
        spaceObject.SetActive(false);
        skillObject.SetActive(false);
        warningObject.SetActive(false);
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
            warningObject.SetActive(true);
            warningAnimator.enabled = true;
        }
        else 
        {
            EmotionImage.sprite = EmotionImages[3];
            warningObject.SetActive(false);
            warningAnimator.enabled = false;
        }
    } // HP ????

    public void SetUI_MP(int current, int max)
    {
        MP_Image.fillAmount = (float)current / max;
        if(MP_Image.fillAmount ==1)
        {
            spaceObject.SetActive(true);
            spaceAnimator.enabled = true;
        }
        else
        {
            spaceObject.SetActive(false);
            spaceAnimator.enabled = false;
        }
    } // MP ????

    public void SetScore(int currentScore)
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        score = currentScore;

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
        GameManager_World.Instance.bPause = false;
    } // ???? ????

    public void OnClick_LoadToMain()
    {
        SceneManager.LoadScene("mainmenu");
    } // ????????????

    public void OnClick_Record(Text text)
    {
        recordObject.SetActive(true);
        text.text = score.ToString();
    }

    public void OnClick_RecordScore(bool bRecord)
    {
        if(bRecord)
        {
            if (inputField.text == "")
                inputField.text = "Guest";
            rankData.rankList.Add(new RankData.RankEntry(score, inputField.text));
            rankData.SortRanksDescending(); 
            rankData.SaveToFile(); 

            recordButton.enabled = false;
        }
        recordObject.SetActive(false);
    }

    public IEnumerator UI_Skill(float skillTime)
    {
        skillObject.SetActive(true);
        skillAnimator.enabled = true;
        Debug.Log("기술 사용");
        yield return new WaitForSeconds(skillTime);
        skillAnimator.enabled = false;
        skillObject.SetActive(false);
    }
}
