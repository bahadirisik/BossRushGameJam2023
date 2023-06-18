using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameBalloons : MonoBehaviour
{
    public bool theRightOne = false;
	bool isFinished;

	[SerializeField] private PlayerHealth playerHealth;
	[SerializeField] private GameObject gameEndBalloon;
	[SerializeField] private EnemyHealth enemyHealth;

	private void Start()
	{
		isFinished = false;
	}

	private void Update()
	{
		if(enemyHealth.GetEnemyHealth() <= 0f)
		{
			if (isFinished)
				return;

			if (theRightOne)
			{
				gameEndBalloon.GetComponent<EndGameBalloons>().isFinished = true;
				gameEndBalloon.SetActive(false);
			}
			else
			{
				gameEndBalloon.GetComponent<EndGameBalloons>().isFinished = true;
				playerHealth.InstaDamage(999);
			}
		}
	}

	private void OnDestroy()
	{
		/*if (isFinished)
			return;

		if (theRightOne)
		{
			gameEndBalloon.GetComponent<EndGameBalloons>().isFinished = true;
			gameEndBalloon.SetActive(false);
		}
		else
		{
			gameEndBalloon.GetComponent<EndGameBalloons>().isFinished = true;
			playerHealth.InstaDamage(999);
		}*/
	}
}
