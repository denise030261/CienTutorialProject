using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CloseButton : MonoBehaviour
{
    [SerializeField] GameObject closeObject;
    Button closeButton;
    private void Awake()
    {
        closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(OnClick_Close);
    }

    void OnClick_Close()
    {
        closeObject.SetActive(false);
    }
}
