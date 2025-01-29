using System;
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

    public GameObject[] weapons;
    public GameObject weaponInstance;
    public int selectWeapon;

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
        animators[0].Rebind();
        animators[0].enabled = true;
        selectWeapon = 0;
        weaponInstance = Instantiate(weapons[0], GetMousePosition(), Quaternion.identity); // Init Weapon
    }
    // Update is called once per frame
    void Update()
    {
        if (weaponInstance != null)
        {
            weaponInstance.transform.position = GetMousePosition();
        } // Move Weapon

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponScript.Instance.currentWeapon = 0;
            for(int i=0;i<4;i++)
            {
                animators[i].enabled = false;
            }
            ChangeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponScript.Instance.currentWeapon = 1;
            for (int i = 0; i < 4; i++)
            {
                animators[i].enabled = false;
            }
            ChangeWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponScript.Instance.currentWeapon = 2;
            for (int i = 0; i < 4; i++)
            {
                animators[i].enabled = false;
            }
            ChangeWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WeaponScript.Instance.currentWeapon = 3;
            for (int i = 0; i < 4; i++)
            {
                animators[i].enabled = false;
            }
            ChangeWeapon(3);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(weaponInstance);
        }
        if (Input.GetMouseButtonUp(0))
        {
            weaponInstance = Instantiate(weapons[selectWeapon], GetMousePosition(), Quaternion.identity);
        }
    }

    void ChangeWeapon(int weapon)
    {
        if (weaponInstance != null)
        {
            Destroy(weaponInstance);
        }
        weaponInstance = Instantiate(weapons[weapon], GetMousePosition(), Quaternion.identity);

        animators[weapon].Rebind();
        animators[weapon].enabled = true;
        selectWeapon = weapon;
        SelectedSlot(weapon);
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

    private Vector3 GetMousePosition()
    {
        Vector3 position = Input.mousePosition;
        position = Camera.main.ScreenToWorldPoint(position);
        position.z = 0;

        return position;
    }

}
