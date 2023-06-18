using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlue : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Wall")
		{
			if (FindObjectOfType<GameMaster>().isGameFinished)
				return;
			FindObjectOfType<PlayerHealth>().InstaDamage(999);
		}

		Destroy(gameObject);
	}
}
