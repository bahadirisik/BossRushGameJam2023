using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusBoss : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private GameObject bossAttack2;
    [SerializeField] private GameObject bossAttack1;
    [SerializeField] private GameObject bossAttack3;

    [SerializeField] private Transform[] startPositions;

    private float bubbleMoveSpeed = 1.2f;
    private float sharpLeafMoveSpeed = 25f;

    public bool floorCanDamage = false;

    private float swampStartDamageTimer = 1.5f;
    private float swampDamageTimer;
    void Start()
    {
        swampDamageTimer = swampStartDamageTimer;
    }

    void Update()
    {
        if (playerHealth == null)
            return;

		if (floorCanDamage && swampDamageTimer <= 0f)
		{
            swampDamageTimer = swampStartDamageTimer;
            playerHealth.InstaDamage(5);
		}


        swampDamageTimer -= Time.deltaTime;
    }

    public void BossAttack2()
	{
        float randomRotation = Random.Range(0f,360f);
        GameObject bubbleAttackGO = Instantiate(bossAttack2,transform.position,Quaternion.Euler(0f,0f,randomRotation));
		for (int i = 0; i < bubbleAttackGO.transform.childCount; i++)
		{
            GameObject bubbleGO = bubbleAttackGO.transform.GetChild(i).gameObject;
            bubbleGO.GetComponent<Rigidbody2D>().AddForce(bubbleMoveSpeed * bubbleGO.transform.right, ForceMode2D.Impulse);
        }
        Destroy(bubbleAttackGO,35f);
	}

    public void BossAttack1()
	{
		for (int i = 0; i < 5; i++)
		{
            int randomPosition = Random.Range(0, startPositions.Length);
            GameObject swampLavaGO = Instantiate(bossAttack1, startPositions[randomPosition].position, Quaternion.identity);
            Destroy(swampLavaGO, 5f);
        }
	}

    public void BossAttack3()
	{
        GameObject sharpLeafGO = Instantiate(bossAttack3,transform.position,Quaternion.identity);
        Vector2 dir = playerHealth.transform.position - transform.position;
        sharpLeafGO.transform.right = dir;
        sharpLeafGO.GetComponent<Rigidbody2D>().AddForce(sharpLeafGO.transform.right.normalized * sharpLeafMoveSpeed,ForceMode2D.Impulse);
        Destroy(sharpLeafGO,5f);
	}

    public void BosAttack()
	{

	}
}
