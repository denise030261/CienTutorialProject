using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public static WeaponScript Instance { get; private set; } = null;

    public GameObject[] weapons;
    public int currentWeapon;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 0;
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
            Vector3 position = Input.mousePosition;
            position = Camera.main.ScreenToWorldPoint(position);
            position.z = 0;

            GameObject weaponInstance = Instantiate(weapons[currentWeapon], position, Quaternion.identity);
            Destroy(weaponInstance, .1f);
        }
    }
}
