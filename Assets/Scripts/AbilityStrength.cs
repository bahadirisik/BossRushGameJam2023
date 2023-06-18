using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStrength : MonoBehaviour
{
	[SerializeField] private GameObject abilityDeathEffect;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			FindObjectOfType<AudioManager>().Play("Ability");
			GameObject deathEffectGO = Instantiate(abilityDeathEffect, transform.position,Quaternion.Euler(-90f,0f,0f));
			Destroy(deathEffectGO, 2f);
			collision.GetComponent<PlayerHealth>().IncreasePlayerStrength(20);
			Destroy(gameObject);
		}
	}
}
