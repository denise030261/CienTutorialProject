  
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;
    public static BGMManager Instance { get { return instance; } }

    public AudioSource audioSource;
    public AudioSource audioSFXSource;
    private AudioClip bgmClip;
    private float bgmVolume = 1.0f;

    [SerializeField] Slider audioSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 변경 시에도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }

       private void Start()
        {
        Debug.Log(PlayerPrefs.GetFloat("BGM", 0.5f));
        audioSource.volume = PlayerPrefs.GetFloat("BGM", 0.5f);
        }

    public void PlayBGM(AudioClip clip)
    {
        bgmClip = clip;
        bgmVolume = PlayerPrefs.GetFloat("BGM", 0.5f);
            audioSource.clip = bgmClip;
            audioSource.volume = PlayerPrefs.GetFloat("BGM", 0.5f); 
            audioSource.loop = true;
            audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        audioSource.volume = bgmVolume;
    }

    public float GetBGMVolume()
    {
        return bgmVolume;
    }

    public void PlaySFX(AudioClip clip, bool bLoop)
    {
        audioSFXSource.clip = clip;
        audioSFXSource.volume = PlayerPrefs.GetFloat("BGM", 0.5f);
        audioSFXSource.loop = bLoop;
        audioSFXSource.Play();
    }

    public void StopSFX()
    {
        audioSFXSource.Stop();
    }

    public void SetSFXVolume(float volume)
    {
        bgmVolume = volume;
        audioSFXSource.volume = bgmVolume;
    }

    public float GetSFXVolume()
    {
        return bgmVolume;
    }
}
