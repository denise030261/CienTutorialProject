using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Option : MonoBehaviour
{
    public Slider slider;

    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public GameObject ToggleCheck;
    public Text currentStateText;

    Resolution[] resolutionArray = new Resolution[3];
    float curVolume = 0;
    bool curFull = false;
    int curHeight = 0;
    int curWidth = 0;


    private void Awake()
    {
        CurrentState();
    }

    void Start()
    {
        InitializeResolutionOptions();
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);

        fullscreenToggle.isOn=Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false; // FullScreen 여부
        
        curFull = Screen.fullScreen;
        curHeight = Screen.height;
        curWidth = Screen.width;
    }

    private void Update()
    {
        BGMManager.Instance.audioSource.volume = slider.value;
    }
    private void OnEnable()
    {
        CurrentState();
    }

    private void CurrentState()
    {
        slider.value = PlayerPrefs.GetFloat("BGM", 0.5f);
        slider.value = PlayerPrefs.GetFloat("SFX", 0.5f);
        curVolume = slider.value;
    }

    void InitializeResolutionOptions()
    {
        resolutionDropdown.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        int resolutionIndex = 0;

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + " x " + resolution.height;
            if (Mathf.Approximately((float)resolution.width / resolution.height, 16f / 9f) )
            {
                resolutionArray[resolutionIndex] = resolution;
                resolutionIndex++;
                resolutionDropdown.options.Add(new Dropdown.OptionData(option));

                if (Screen.width == resolution.width)
                {
                    resolutionDropdown.value = resolutionIndex;
                } //현재 해상도 상태
            }
        }

        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
    }

    void ChangeResolution(int index)
    {
        Resolution[] resolutions = resolutionArray;

        if (index >= 0 && index < resolutions.Length)
        {
            Resolution selectedResolution = resolutions[index];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

            int IsFullScreen;

            if (Screen.fullScreen)
            {
                IsFullScreen = 1;
            }
            else
            {
                IsFullScreen = 0;
            }
            PlayerPrefs.SetInt("ResolutionFullScreen", IsFullScreen);
            PlayerPrefs.SetInt("ResolutionHeight", selectedResolution.height);
            PlayerPrefs.SetInt("ResolutionWidth", selectedResolution.width);
        }
    }

    void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        int IsFullScreen;
        if (isFullscreen)
        {
            IsFullScreen = 1;
        }
        else
        {
            IsFullScreen = 0;
        }
        PlayerPrefs.SetInt("ResolutionFullScreen", IsFullScreen);
    }

    public void OnClick_Previous()
    {
        PlayerPrefs.SetFloat("BGM", curVolume);
        PlayerPrefs.SetFloat("SFX", curVolume);

        if(curFull)
            PlayerPrefs.SetInt("ResolutionFullScreen",1);
        else
            PlayerPrefs.SetInt("ResolutionFullScreen",0);

        PlayerPrefs.SetInt("ResolutionHeight", curHeight);
        PlayerPrefs.SetInt("ResolutionWidth", curWidth);
        gameObject.SetActive(false);
        BGMManager.Instance.audioSource.volume = curVolume;
    }

    public void OnClick_Save()
    {
        PlayerPrefs.SetFloat("BGM", slider.value);
        PlayerPrefs.SetFloat("SFX", slider.value);
        gameObject.SetActive(false);
    }
}
