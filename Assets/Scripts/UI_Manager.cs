using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Image HP_Image;
    public Image MP_Image;

    public GameObject GameOverImage;
    public static UI_Manager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }
    public void SetUI_HP(int current, int max)
    {
        HP_Image.fillAmount = (float)current / max;
    } // HP 상태
    public void SetUI_MP(int current, int max)
    {
        MP_Image.fillAmount = (float)current / max;
    } // MP 상태
    public void OnClick_Retry()
    {
        ;
    } // 다시 시작
    public void OnClick_LoadToMain()
    {
        ;
    } // 메인화면으로
}
