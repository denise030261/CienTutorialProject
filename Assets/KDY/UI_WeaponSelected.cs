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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectedSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectedSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectedSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SelectedSlot(3);
        }
    }
    void SelectedSlot(int Selected)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == Selected)
            {
                if (!IsSelected[i])
                {
                    SelectedWeapon[i].SetActive(true);
                    IsSelected[i] = true;
                }
                else
                {
                    SelectedWeapon[i].SetActive(false);
                    IsSelected[i] = false;
                }
            }
            else
            {
                SelectedWeapon[i].SetActive(false);
                IsSelected[i] = false;
            }
        }
    } // 무기를 선택했을 때
}
