using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	[SerializeField] private int levelIndex;
	[SerializeField] private LevelLoader levelLoader;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			PortalToTheLevel(levelIndex);
		}
	}

	private void PortalToTheLevel(int index)
	{
		levelLoader.LoadNextLevel(index);
	}
}
