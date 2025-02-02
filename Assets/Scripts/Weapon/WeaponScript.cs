using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public static WeaponScript Instance { get; private set; } = null;

    public GameObject[] weapons;
    public int currentWeapon;
    public int instantiatedWeapon;
    public GameObject weaponInstance;

    public AudioClip[] attackClips;

    [SerializeField] private UI_WeaponSelected weaponSelected;
    private int selectNum;

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
        if (GameManager_World.Instance.bPause)
        {
            if (weaponInstance != null)
            {
                Destroy(weaponInstance);
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (weaponInstance != null)
            {
                Destroy(weaponInstance);
            }

            instantiatedWeapon = currentWeapon;

            weaponInstance = Instantiate(weapons[currentWeapon], GetMousePosition(), Quaternion.identity);

            if (currentWeapon == 1 || currentWeapon == 2)
            {
                BGMManager.Instance.PlaySFX(attackClips[currentWeapon], false);
                Destroy(weaponInstance, .1f);
            }
            else
            {
                BGMManager.Instance.PlaySFX(attackClips[currentWeapon], true);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (instantiatedWeapon == 0 || instantiatedWeapon == 3)
            {
                BGMManager.Instance.StopSFX();
                Destroy(weaponInstance);
            }
        }

        if (weaponInstance != null && (instantiatedWeapon == 0 || instantiatedWeapon == 3))
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
