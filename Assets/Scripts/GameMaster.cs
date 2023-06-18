using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool isGameFinished = false;

    [SerializeField] private GameObject gun;

    [SerializeField] private int enemyCount;
    [SerializeField] private int startEnemyCount;

    void Start()
    {
        enemyCount = startEnemyCount;
        isGameFinished = false;
    }

    void Update()
    {
        if (isGameFinished)
        {
            return;
        }

        CheckForEnemies();
    }

    void CheckForEnemies()
	{
        if(enemyCount <= 0)
		{
            GameFinished();
		}
	}

    public void GameFinished()
	{
        isGameFinished = true;
        //Instantiate(gun,new Vector3(-13f,0f,0f),Quaternion.identity);
        gun.SetActive(true);
	}

    public void UpdateEnemyCount(int amount)
	{
        enemyCount += amount;
	}
}
