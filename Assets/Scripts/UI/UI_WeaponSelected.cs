using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 수정 사항 : Q, W, E, R은 숫자로 키보드 변환
public class UI_WeaponSelected : MonoBehaviour
{
    public GameObject[] SelectedWeapon;
    private bool[] IsSelected = new bool[4];

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            IsSelected[i] = false;
        }
    } // 선택 유무 초기화

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
    } // 무기를 선택했을 때
}
