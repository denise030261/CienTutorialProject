using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
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
        SceneManager.LoadScene("option");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void BackSettings()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
