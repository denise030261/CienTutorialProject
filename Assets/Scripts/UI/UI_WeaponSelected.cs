using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ???? ???? : Q, W, E, R?? ?????? ?????? ????
public class UI_WeaponSelected : MonoBehaviour
{
    public GameObject[] SelectedWeapon;
    public Animator[] animators;
    private bool[] IsSelected = new bool[4];
    public static UI_WeaponSelected Instance { get; private set; } = null;

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            IsSelected[i] = false;
        }
    } // ???? ???? ??????

    private void Start()
    {
        SelectedWeapon[0].SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            animators[i].enabled = false;
        }
        animators[0].enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponScript.Instance.currentWeapon = 0;
            for(int i=0;i<4;i++)
            {
                animators[i].enabled = false;
            }
            animators[0].enabled = true;
            SelectedSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponScript.Instance.currentWeapon = 1;
            for (int i = 0; i < 4; i++)
            {
                animators[i].enabled = false;
            }
            animators[1].enabled = true;
            SelectedSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponScript.Instance.currentWeapon = 2;
            for (int i = 0; i < 4; i++)
            {
                animators[i].enabled = false;
            }
            animators[2].enabled = true;
            SelectedSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WeaponScript.Instance.currentWeapon = 3;
            for (int i = 0; i < 4; i++)
            {
                animators[i].enabled = false;
            }
            animators[3].enabled = true;
            SelectedSlot(3);
        }
    }
    void SelectedSlot(int Selected)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == Selected)
            {
                SelectedWeapon[i].SetActive(true);
            }
            else
            {
                SelectedWeapon[i].SetActive(false);
                IsSelected[i] = false;
            }
        }
    } // ?????? ???????? ??
}
