using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    float fireRate;
    [SerializeField] float startFireRate;
    [SerializeField] float bulletSpeed = 15f;

    [SerializeField] private bool isShotgun;
    [SerializeField] private string gunShot;

	private void Start()
	{
        fireRate = startFireRate;
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetMouseButton(0) && fireRate <= 0f)
        {
            if (isShotgun)
                GunShootMultiple();
            else
                GunShoot();
        }

        fireRate -= Time.deltaTime;
    }

    void GunShoot()
	{
        FindObjectOfType<AudioManager>().Play(gunShot);
        fireRate = startFireRate;
        GameObject bulletPrefabGO = Instantiate(bulletPrefab.gameObject, firePoint.position, Quaternion.identity);
        bulletPrefabGO.transform.right = firePoint.right;
        bulletPrefabGO.GetComponent<Rigidbody2D>().AddForce(firePoint.right * bulletSpeed,ForceMode2D.Impulse);
        Destroy(bulletPrefabGO,4f);
	}

    void GunShootMultiple()
	{
        FindObjectOfType<AudioManager>().Play(gunShot);
        fireRate = startFireRate;
        GameObject bulletPrefabGO = Instantiate(bulletPrefab.gameObject, firePoint.position, Quaternion.identity);
        bulletPrefabGO.transform.right = firePoint.right;
		for (int i = 0; i < bulletPrefabGO.transform.childCount; i++)
		{
            GameObject shotgunBullet = bulletPrefabGO.transform.GetChild(i).gameObject;
            shotgunBullet.GetComponent<Rigidbody2D>().AddForce(shotgunBullet.transform.right * bulletSpeed, ForceMode2D.Impulse); ;
		}
        Destroy(bulletPrefabGO, 4f);
    }
}
