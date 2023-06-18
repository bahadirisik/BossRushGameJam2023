using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunSelect : MonoBehaviour
{
    public static List<string> weaponTags = new List<string>();

	private void Start()
	{
        AddFormerWeapons();
	}
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectWeapon(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectWeapon(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectWeapon(6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectWeapon(7);
        }
    }

    void SelectWeapon(int weaponNumber)
	{
        if((transform.GetChild(0).childCount + transform.GetChild(1).childCount) < (weaponNumber + 1))
		{
            return;
		}

        foreach (Transform child in transform.GetChild(0).transform)
        {
            child.gameObject.SetActive(false);
            child.parent = transform.GetChild(1).transform;
        }

        foreach (Transform child in transform.GetChild(1).transform)
        {
            if (child.GetComponent<PickUp>().weaponNumber == weaponNumber)
            {
                child.gameObject.SetActive(true);
                child.parent = transform.GetChild(0).transform;
            }
        }
    }

    void AddFormerWeapons()
	{
        if(weaponTags.Count <= 0)
		{
            return;
		}

        GameObject firstGun = GameObject.FindGameObjectWithTag(weaponTags[0]);
        firstGun.GetComponent<PickUp>().FirstWeapon(gameObject);
        for (int i = 1; i < weaponTags.Count; i++)
		{
            if(weaponTags[i] != null)
			{
                GameObject formerGuns = GameObject.FindGameObjectWithTag(weaponTags[i]);
                formerGuns.GetComponent<PickUp>().TakeWeapon(gameObject);
            }
        }
	}
}
