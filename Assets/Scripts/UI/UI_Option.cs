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

    Resolution[] resolutionArray = new Resolution[20];
    float curVolume = 0;
    bool curFull = false;
    int curHeight = 0;
    int curWidth = 0;

    void Start()
    {
        InitializeResolutionOptions();
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
        LoadSettings();
    }

    private void OnEnable()
    {
        LoadSettings();
    }
    void LoadSettings()
    {
        curHeight = Screen.height;
        curWidth = Screen.width;
        curFull = Screen.fullScreen;
        curVolume = PlayerPrefs.GetFloat("BGM", 0.5f);

        slider.value = curVolume;
        fullscreenToggle.isOn = curFull;
    }

    void InitializeResolutionOptions()
    {
        resolutionDropdown.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        int resolutionIndex = 0;

        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + " x " + resolution.height;

            if (Mathf.Approximately((float)resolution.width / resolution.height, 16f / 9f) &&
                resolution.refreshRateRatio.numerator / (float)resolution.refreshRateRatio.denominator == 60)
            {
                Debug.LogError(resolution.refreshRateRatio.ToString());
                resolutionArray[resolutionIndex] = resolution;
                resolutionIndex++;
                resolutionDropdown.options.Add(new Dropdown.OptionData(option));

                if (Screen.width == resolution.width)
                {
                    resolutionDropdown.value = resolutionIndex;
                } 
            }
        }

        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
    }

    private void Update()
    {
        BGMManager.Instance.audioSource.volume = slider.value;
    }

    void ChangeResolution(int index)
    {
        Resolution[] resolutions = resolutionArray;

        if (index >= 0 && index < resolutions.Length)
        {
            Resolution selectedResolution = resolutions[index];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        }
    }

    void ToggleFullscreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.FullScreenWindow);
        }
        else
        {
            // 창 모드 설정
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.Windowed);
        }
    }


    public void OnClick_Previous()
    {
        PlayerPrefs.SetFloat("BGM", curVolume);
        PlayerPrefs.SetFloat("SFX", curVolume);

        slider.value = curVolume;
        BGMManager.Instance.audioSource.volume = curVolume;

        for (int i = 0; i < resolutionArray.Length; i++)
        {
            if (resolutionArray[i].width == curWidth && resolutionArray[i].height == curHeight)
            {
                resolutionDropdown.value = i;
                break;
            }
        }
        fullscreenToggle.isOn = curFull;
        Screen.SetResolution(curWidth, curHeight, curFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);

        gameObject.SetActive(false);
    }

    public void OnClick_Save()
    {
        PlayerPrefs.SetFloat("BGM", slider.value);
        PlayerPrefs.SetFloat("SFX", slider.value);

        gameObject.SetActive(false);
    }
}
