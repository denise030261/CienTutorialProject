using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonEventHandler : MonoBehaviour
{
    public void ChangeImage(Sprite changeSprite)
    {
        Image image = GetComponent<Image>();
        image.sprite = changeSprite;
    }

    public void ChangeAnimation(bool bCheck)
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = true;
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        animator.SetBool("bExit", bCheck);
        Debug.Log($"Animator State: bExit = {bCheck}");
    }
}
