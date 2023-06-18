using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloons : MonoBehaviour
{
	int randomDamage;
	private void OnTriggerStay2D(Collider2D collision)
	{
		randomDamage = Random.Range(15,20);

		if(collision.tag == "Player")
		{
			collision.gameObject.GetComponent<PlayerHealth>().PlayerGetsDamage(randomDamage);
		}
	}
}
