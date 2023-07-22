
namespace BGMu
{    
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;
    public static BGMManager Instance { get { return instance; } }

    private AudioSource audioSource;
    private AudioClip bgmClip;
    private bool isBGMPlaying = false;
    private float bgmVolume = 1.0f; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmClip = clip;
        if (!isBGMPlaying)
        {
            audioSource.clip = bgmClip;
            audioSource.volume = bgmVolume; 
            audioSource.loop = true;
            audioSource.Play();
            isBGMPlaying = true;
        }
    }

    public void StopBGM()
    {
        if (isBGMPlaying)
        {
            audioSource.Stop();
            isBGMPlaying = false;
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        if (isBGMPlaying)
        {
            audioSource.volume = bgmVolume; 
        }
    }

    public float GetBGMVolume()
    {
        return bgmVolume;
    }
}
}