using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public void StartAnimation()
    {
        GameManager_World.Instance.StartGame(false);
    }

    public void EndAnimation()
    {
        GameManager_World.Instance.EndGame(false);
    }

    public void CloseObject()
    {
        gameObject.SetActive(false);
    }

}
