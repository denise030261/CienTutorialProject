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
    public Text StageText;

    public GameObject GameOverImage;
    public static UI_Manager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        ScoreText.text = GameManager_World.Instance.Score.ToString("D5");
        StageText.text = "Stage : "+GameManager_World.Instance.Stage.ToString();
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
    public void OnClick_Retry()
    {
        
    } // ???? ????
    public void OnClick_LoadToMain()
    {
        
    } // ????????????
}
