using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject alertObject;
    [SerializeField] GameObject optionObject;
    [SerializeField] RankData rankData;
    [SerializeField] GameObject contents;
    [SerializeField] GameObject rankObject;
    private void Start()
    {
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
            TMP_Text rankText = contentObject.transform.GetChild(0).GetComponent<TMP_Text>();
            rankText.text = (i + 1).ToString();
            TMP_Text nameText = contentObject.transform.GetChild(1).GetComponent<TMP_Text>();
            nameText.text = rankData.rankList[i].playerName;
            TMP_Text scoreText = contentObject.transform.GetChild(2).GetComponent<TMP_Text>();
            scoreText.text = rankData.rankList[i].score.ToString();
        }
        for(int i= rankData.rankList.Count;i<contents.transform.childCount;i++)
        {
            GameObject contentObject = contents.transform.GetChild(i).gameObject;
            TMP_Text rankText = contentObject.transform.GetChild(0).GetComponent<TMP_Text>();
            rankText.text = (i + 1).ToString();
        }
    }
}
