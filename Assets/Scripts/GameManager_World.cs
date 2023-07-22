using UnityEngine;

public class GameManager_World : MonoBehaviour
{
    public int Score;
    public int Stage;
    public int InitialHp;
    public int InitialMp;

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

        AudioClip bgmClip = Resources.Load<AudioClip>("Music/BGM/BGM");
        BGMManager.Instance.PlayBGM(bgmClip);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject settingsPrefab = Resources.Load<GameObject>("optionscene");
            Time.timeScale = 0;

            if (settingsPrefab != null)
            {
                Instantiate(settingsPrefab);
            }
            else
            {
                Debug.LogError("Could not load the 'optionscene' prefab.");
            }
        }
    }
}
