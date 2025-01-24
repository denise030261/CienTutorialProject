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
        AudioClip bgmClip = Resources.Load<AudioClip>("Music/BGM/BGM_MainMenu2");
        BGMManager.Instance.PlayBGM(bgmClip);

        GameStartShowAnimation.Instance.showObject = GameObject.FindWithTag("Show");
        GameStartShowAnimation.Instance.showAnimator = GameStartShowAnimation.Instance.showObject.GetComponent<Animator>();
        if (!GameStartShowAnimation.Instance.startAnimation)
        {
            GameStartShowAnimation.Instance.showObject.SetActive(false);
            GameStartShowAnimation.Instance.startAnimation = true;
        }
    }

    public void NewGame()
    {
        StartCoroutine(LoadGame());
    }

    public void ContinueGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        GameStartShowAnimation.Instance.showObject.SetActive(true);
        GameStartShowAnimation.Instance.showAnimator.SetBool("isShow", false);
        yield return new WaitForSeconds(2);
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
            if (i > 20)
                break;

            GameObject contentObject = contents.transform.GetChild(i+1).gameObject;
            TMP_Text rankText = contentObject.transform.GetChild(0).GetComponent<TMP_Text>();
            rankText.text = (i + 1).ToString();
            TMP_Text nameText = contentObject.transform.GetChild(1).GetComponent<TMP_Text>();
            nameText.text = rankData.rankList[i].playerName;
            TMP_Text scoreText = contentObject.transform.GetChild(2).GetComponent<TMP_Text>();
            scoreText.text = rankData.rankList[i].score.ToString();
        }
        for (int i = rankData.rankList.Count; i < contents.transform.childCount; i++)
        {
            if (i+1>20)
                return;
            GameObject contentObject = contents.transform.GetChild(i + 1).gameObject;
            TMP_Text rankText = contentObject.transform.GetChild(0).GetComponent<TMP_Text>();
            rankText.text = (i + 1).ToString();
            TMP_Text nameText = contentObject.transform.GetChild(1).GetComponent<TMP_Text>();
            nameText.text = "-";
            TMP_Text scoreText = contentObject.transform.GetChild(2).GetComponent<TMP_Text>();
            scoreText.text = "-";
        }
    }
}
