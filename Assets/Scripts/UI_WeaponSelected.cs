using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� : Q, W, E, R�� ���ڷ� Ű���� ��ȯ
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
    } // ���� ���� �ʱ�ȭ

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
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
    } // ���⸦ �������� ��
}
