using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{
    [SerializeField] GameObject optionObject;
    [SerializeField] GameObject methodObject;
    public void OnClick_Continue()
    {
        GameManager_World.Instance.bPause = false;
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void OnClick_Option()
    {
        optionObject.SetActive(true);
    }

    public void OnClick_Method()
    {
        methodObject.SetActive(true);
    }

    public void OnClick_Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("mainmenu");
    }
}
