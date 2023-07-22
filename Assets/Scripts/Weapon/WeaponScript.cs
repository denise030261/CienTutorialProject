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

    //private AudioSource audioSource;
    //public AudioClip attackClip;
    public AudioSource[] audioSources; // ?????? ????

    private void Awake()
    {
        Instance = this;
        //audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 0;
        weaponInstance = null;
        foreach (var audioSource in audioSources)
        {
            audioSource.enabled = false;
        } // ?????? ????????
    }

    // Update is called once per frame
    void Update()
    {
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
                Destroy(weaponInstance, .1f);
                audioSources[1].enabled = false;
                audioSources[2].enabled = false;
            }

            for(int i=0;i<4;i++)
            {
                if(currentWeapon==i)
                {
                    audioSources[i].enabled = true;
                    audioSources[i].Play();
                }
            }
            //audioSource.clip = attackClip;
            //audioSource.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (instantiatedWeapon == 0 || instantiatedWeapon == 3)
            {
                Destroy(weaponInstance);
                audioSources[0].enabled = false;
                audioSources[3].enabled = false;
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
