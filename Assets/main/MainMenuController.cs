using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text highScoreText;

    private void Start()
    {
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
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
        GameObject settingsPrefab = Resources.Load<GameObject>("optionscene");

        if (settingsPrefab != null)
        {
            Instantiate(settingsPrefab);
        }
        else
        {
            Debug.LogError("Could not load the 'optionscene' prefab.");
        }
    }

    public void Opentuto()
    {
        GameObject settingsPrefab = Resources.Load<GameObject>("tuto");

        if (settingsPrefab != null)
        {
            Instantiate(settingsPrefab);
        }
        else
        {
            Debug.LogError("Could not load the 'tuto' prefab.");
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
        Destroy(gameObject);
    }
}
