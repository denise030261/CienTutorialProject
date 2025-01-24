using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartShowAnimation : MonoBehaviour
{
    public Animator showAnimator;
    public bool startAnimation = false;
    public GameObject showObject;

    public static GameStartShowAnimation Instance = null;

    void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
