using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBoss : MonoBehaviour
{
    private int theRightOne = 1;

    [SerializeField] private GameObject[] bouncyBall;
    [SerializeField] private GameObject enemyWithBalloon;
    [SerializeField] private GameObject[] balloonsAttack;
    [SerializeField] private GameObject[] endGameBalloons;
    [SerializeField] private GameObject[] deathEffects;
    [SerializeField] private EnemyHealth enemyHealth;

    [SerializeField] private Animator anim;
    
    void Start()
    {
       theRightOne = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {

        if(enemyHealth.GetEnemyHealth() <= 700)
		{
            anim.SetBool("SecondPhase",true);
		}
    }

    public void BouncyBallAttack()
	{
        int randomAmount = Random.Range(18,22);
		for (int i = 0; i < randomAmount; i++)
		{
            int randomBall = Random.Range(0,bouncyBall.Length);
            Instantiate(bouncyBall[randomBall],transform.position,Quaternion.identity);
		}
	}

    public void SpawnEnemyWithBalloon()
	{
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-16, 16), Random.Range(-8, 8), 0f);
            Instantiate(enemyWithBalloon, randomPosition, Quaternion.identity);
        }
    }

    public void BalloonsAttack()
	{
        FindObjectOfType<AudioManager>().Play("ClownLaugh");
        GameObject balloonGO = Instantiate(balloonsAttack[Random.Range(0,balloonsAttack.Length)]);
        Destroy(balloonGO,10f);
	}

	private void OnDestroy()
	{
        foreach (GameObject balloon in endGameBalloons)
        {
            if (balloon == null)
                return;
            balloon.transform.position = new Vector3(balloon.transform.position.x,5.8f,0f);
        }

        if (theRightOne == 0)
        {
            GameObject deathEffectGO = Instantiate(deathEffects[0], transform.position, Quaternion.identity);
            endGameBalloons[0].GetComponent<EndGameBalloons>().theRightOne = true;
        }
        else
        {
            GameObject deathEffectGO = Instantiate(deathEffects[1], transform.position, Quaternion.identity);
            endGameBalloons[1].GetComponent<EndGameBalloons>().theRightOne = true;
        }
    }

    public void BosAnim()
	{

	}
}
