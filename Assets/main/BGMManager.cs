  
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;
    public static BGMManager Instance { get { return instance; } }

    private AudioSource audioSource;
    private AudioClip bgmClip;
    private float bgmVolume = 1.0f; 

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

        audioSource = GetComponent<AudioSource>();
    }

       private void Start()
        {
            bgmVolume = PlayerPrefs.GetFloat("BGM", 0.5f);    
        }

        private void Update()
        {
            PlayerPrefs.SetFloat("BGM", audioSource.volume);
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
}
