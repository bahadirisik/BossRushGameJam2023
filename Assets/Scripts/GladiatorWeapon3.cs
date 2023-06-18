using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorWeapon3 : MonoBehaviour
{
	[SerializeField] private GameObject totemDeathEffect;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			collision.GetComponent<PlayerHealth>().PlayerGetsDamage(20);
		}
		else if(collision.tag == "EnemyTotem")
		{
			FindObjectOfType<AudioManager>().Play("Totem");
			GameObject totemDeathEffectGO = Instantiate(totemDeathEffect,collision.transform.position,Quaternion.identity);
			Destroy(totemDeathEffectGO,2f);
			Destroy(collision.gameObject);
		}

		Destroy(gameObject);
	}
}
