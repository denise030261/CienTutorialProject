using UnityEngine;
using UnityEngine.UI;

public class GameManager_World : MonoBehaviour
{
    [SerializeField] GameObject pauseObject;
    public int Score;
    public int Stage;
    public int InitialHp;
    public int InitialMp;
    public bool bPause;

    public static GameManager_World Instance { get; private set; } = null;

    [Space(30)]
    [Header("Animation")]
    [SerializeField] GameObject startObject;
    Animator startAnimator;
    [SerializeField] GameObject endObject;
    Animator endAnimator;

    private void Awake()
    {
        Instance = this;

        startAnimator = startObject.GetComponent<Animator>();
        endAnimator = endObject.GetComponent<Animator>(); 
    }
    void Start()
    {
        Init();
        StartGame(true);

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

    public void EndGame(bool bStart)
    {
        bPause = true;
        endObject.SetActive(bStart);
        endAnimator.enabled = bStart;
    }

    public void StartGame(bool bStart)
    {
        bPause = bStart;
        startObject.SetActive(bStart);
        startAnimator.enabled = bStart;
        StartCoroutine(SpawnerScript.Instance.Spawn());
    }

    private void Init()
    {
        endObject.SetActive(false);
        endAnimator.enabled = false;
        startObject.SetActive(false);
        startAnimator.enabled = false;

        Score = PlayerPrefs.GetInt("Score", 0);
        Stage = PlayerPrefs.GetInt("Stage", 1);
        InitialHp = PlayerPrefs.GetInt("Hp", 5);
        InitialMp = PlayerPrefs.GetInt("Mp", 0);
        pauseObject.SetActive(false);
        bPause = true;
    }
}
