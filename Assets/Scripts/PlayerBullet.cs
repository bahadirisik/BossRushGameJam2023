using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 20;

    [SerializeField] private bool isDestructible;

	private void Start()
	{
        bulletDamage += FindObjectOfType<PlayerHealth>().GetPlayerStrength();
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            bulletDamage = Random.Range(bulletDamage,bulletDamage + 5);
            collision.GetComponent<EnemyHealth>().EnemyTakeDamage(bulletDamage);
        }

		if (isDestructible)
		{
            Destroy(gameObject);
		}
    }
}
