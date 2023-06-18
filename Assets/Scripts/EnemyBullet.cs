using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int enemyBulletDamage = 20;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			enemyBulletDamage = Random.Range(enemyBulletDamage - 5,enemyBulletDamage);
			collision.GetComponent<PlayerHealth>().PlayerGetsDamage(enemyBulletDamage);
		}

		Destroy(gameObject);
	}
}
