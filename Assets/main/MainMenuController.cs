using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text highScoreText;
    [SerializeField] GameObject alertObject;
    [SerializeField] GameObject optionObject;
    [SerializeField] RankData rankData;
    [SerializeField] GameObject contents;
    [SerializeField] GameObject rankObject;
    private void Start()
    {
        //highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();

        alertObject.SetActive(false);
        optionObject.SetActive(false);
        AudioClip bgmClip = Resources.Load<AudioClip>("Music/BGM/BGM");
        BGMManager.Instance.PlayBGM(bgmClip);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettings()
    {
        if (optionObject != null)
        {
            optionObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Could not load the optionObject.");
        }
    }

    public void Opentuto(bool bCheck)
    {
        if (alertObject != null)
        {
            alertObject.SetActive(bCheck);
        }
        else
        {
            Debug.LogError("Could not load the alertObject.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackSettings()
    {
        SceneManager.LoadScene("mainmenu");
    }
    
    
    public void Close()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void OnClick_Rank()
    {
        rankObject.SetActive(true);
        rankData.SortRanksDescending();
        for (int i = 0; i < rankData.rankList.Count; i++)
        {
            if (i >= 20)
                break;

            GameObject contentObject = contents.transform.GetChild(i).gameObject;
            Text rankText = contentObject.transform.GetChild(0).GetComponent<Text>();
            rankText.text = (i + 1).ToString(); 
            Text nameText = contentObject.transform.GetChild(1).GetComponent<Text>();
            nameText.text = rankData.rankList[i].playerName;
            Text scoreText = contentObject.transform.GetChild(2).GetComponent<Text>();
            scoreText.text = rankData.rankList[i].score.ToString();
        }
        for(int i= rankData.rankList.Count;i<contents.transform.childCount;i++)
        {
            GameObject contentObject = contents.transform.GetChild(i).gameObject;
            Text rankText = contentObject.transform.GetChild(0).GetComponent<Text>();
            rankText.text = (i + 1).ToString();
        }
    }
}
