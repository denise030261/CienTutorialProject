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

    private AudioSource audioSource;
    public AudioClip[] attackClips;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
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
                audioSource.loop = false;
                Destroy(weaponInstance, .1f);
            }
            else
            {
                audioSource.loop = true;
            }


            audioSource.clip = attackClips[currentWeapon];
            audioSource.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (instantiatedWeapon == 0 || instantiatedWeapon == 3)
            {
                audioSource.Stop();
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
