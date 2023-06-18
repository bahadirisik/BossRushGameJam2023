using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    [SerializeField] private OctopusBoss octopusBoss;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			octopusBoss.floorCanDamage = false;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			octopusBoss.floorCanDamage = true;
		}
	}
}
