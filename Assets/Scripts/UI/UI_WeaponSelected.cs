using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ???? ???? : Q, W, E, R?? ?????? ?????? ????
public class UI_WeaponSelected : MonoBehaviour
{
    public GameObject[] SelectedWeapon;
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
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponScript.Instance.currentWeapon = 0;
            SelectedSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponScript.Instance.currentWeapon = 1;
            SelectedSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponScript.Instance.currentWeapon = 2;
            SelectedSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WeaponScript.Instance.currentWeapon = 3;
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
