using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource bgmAudioSource;
    public AudioClip bgmClip;

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
    }

    private void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();
        bgmAudioSource.loop = true;
        PlayBGM(bgmClip);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }

    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }

    public void ToggleBGM(bool isOn)
    {
        if (isOn)
        {
            bgmAudioSource.UnPause();
        }
        else
        {
            bgmAudioSource.Pause();
        }
    }
}
