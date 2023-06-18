using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown2 : MonoBehaviour
{
    private int theRightOne = 1;

    [SerializeField] private GameObject[] endGameBalloons;
    [SerializeField] private GameObject[] deathEffects;
    void Start()
    {
        theRightOne = Random.Range(0, 2);
    }


    public void EndGame()
    {
        Debug.Log("AAAAAAA");

        foreach (GameObject balloon in endGameBalloons)
        {
            if (balloon == null)
                return;
            balloon.SetActive(true);
        }

        if (theRightOne == 0)
        {
            Debug.Log("İlk ölüm efekti");
            GameObject deathEffectGO = Instantiate(deathEffects[0], transform.position, Quaternion.identity);
            endGameBalloons[0].GetComponent<EndGameBalloons>().theRightOne = true;
        }
        else
        {
            Debug.Log("İkinci ölüm efekti");
            GameObject deathEffectGO = Instantiate(deathEffects[1], transform.position, Quaternion.identity);
            endGameBalloons[1].GetComponent<EndGameBalloons>().theRightOne = true;
        }
    }
}
