using UnityEngine;

public class GameManager_World : MonoBehaviour
{
    [SerializeField] GameObject pauseObject;
    public int Score;
    public int Stage;
    public int InitialHp;
    public int InitialMp;
    public bool bPause;

    public static GameManager_World Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
        Stage = PlayerPrefs.GetInt("Stage", 1);
        InitialHp = PlayerPrefs.GetInt("Hp", 5);
        InitialMp = PlayerPrefs.GetInt("Mp", 0);
        pauseObject.SetActive(false);
        bPause = false;

        AudioClip bgmClip = Resources.Load<AudioClip>("Music/BGM/BGM");
        BGMManager.Instance.PlayBGM(bgmClip);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            bPause = true;
            Time.timeScale = 0;

            if (pauseObject != null)
            {
                pauseObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Could not load the pauseObject");
            }
        }
    }

    public void OnClick_Pause()
    {
        Time.timeScale = 0;
        bPause = true;

        if (pauseObject != null)
        {
            pauseObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Could not load the pauseObject");
        }
    }
}
