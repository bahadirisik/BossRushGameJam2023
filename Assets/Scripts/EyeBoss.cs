using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBoss : MonoBehaviour
{
    float randomWaitTime;

    public bool isEyeClosed = false;

    [SerializeField] private GameObject openedEye;
    [SerializeField] private GameObject closedEye;
    [SerializeField] private GameObject rageEffect;

    float minAttackTime;
    float maxDefenceTime;
    void Start()
    {
        minAttackTime = 3f;
        maxDefenceTime = 6f;
        isEyeClosed = false;
        StartCoroutine(CloseTheEye());
    }

    public void Rage2()
	{
        FindObjectOfType<AudioManager>().Play("Roar");
        minAttackTime += 0.5f;
        maxDefenceTime -= 0.5f;
        rageEffect.SetActive(true);
	}

	IEnumerator CloseTheEye()
	{
        randomWaitTime = Random.Range(minAttackTime,minAttackTime + 3f);
        GetComponent<EnemyHealth>().enemyCanTakeDamage = false;
        isEyeClosed = false;
        openedEye.SetActive(true);
        closedEye.SetActive(false);

        yield return new WaitForSeconds(randomWaitTime);

        randomWaitTime = Random.Range(maxDefenceTime - 3f, maxDefenceTime);
        GetComponent<EnemyHealth>().enemyCanTakeDamage = true;
        isEyeClosed = true;
        openedEye.SetActive(false);
        closedEye.SetActive(true);

        yield return new WaitForSeconds(randomWaitTime);

        StartCoroutine(CloseTheEye());
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
	}

}
