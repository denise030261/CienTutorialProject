using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public static WeaponScript Instance { get; private set; } = null;

    public GameObject[] weapons;
    public int currentWeapon;
    public GameObject weaponInstance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 0;
        weaponInstance = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && currentWeapon==3)
        {
            Vector3 position = Input.mousePosition;
            position = Camera.main.ScreenToWorldPoint(position);
            position.z = 0;

            GameObject weaponInstance = Instantiate(weapons[currentWeapon], position, Quaternion.identity);
            Destroy(weaponInstance, .01f);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (weaponInstance != null)
            {
                Destroy(weaponInstance);
            }

            weaponInstance = Instantiate(weapons[currentWeapon], GetMousePosition(), Quaternion.identity);

            if (currentWeapon == 1 || currentWeapon == 2)
            {
                Destroy(weaponInstance, .1f);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (currentWeapon == 0 || currentWeapon == 3)
            {
                Destroy(weaponInstance);
            }
        }

        if (weaponInstance != null && (currentWeapon == 0 || currentWeapon == 3))
        {
            weaponInstance.transform.position = GetMousePosition();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 position = Input.mousePosition;
        position = Camera.main.ScreenToWorldPoint(position);
        position.z = 0;

        return position;
    }
}
