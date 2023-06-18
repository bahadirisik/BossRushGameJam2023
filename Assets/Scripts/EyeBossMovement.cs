using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EyeBossMovement : MonoBehaviour
{
    private float eyeBossStartMoveSpeed;
    [SerializeField] private Transform player;

    private bool isEyeClosedMoving;
    private int damage = 10;

    private Vector3 randomPosition;
    [SerializeField] private Transform randomPositionTransform;

    float minY = -5.5f;
    float maxY = 2.5f;
    float maxX = 12f;
    float minX = -12f;

    [SerializeField] private AIDestinationSetter aiDestination;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private EnemyHealth enemyHealth;
    void Start()
    {
        isEyeClosedMoving = false;
        eyeBossStartMoveSpeed = aiPath.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        /*if(enemyHealth.GetEnemyHealth() <= 0)
		{
            BeforeDeath();
		}*/

        if(Vector3.Distance(transform.position,randomPosition) <= 2f)
		{
            isEyeClosedMoving = false;
		}
        
        
    }

	private void FixedUpdate()
	{
        if (player == null)
            return;

        if (GetComponent<EyeBoss>().isEyeClosed)
        {
            EyeClosedMovement();
        }
        else if (!GetComponent<EyeBoss>().isEyeClosed)
        {
            EyeOpenedMovement();
        }
    }

	void EyeClosedMovement()
	{
        if (!isEyeClosedMoving)
        {
            randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        }

        randomPositionTransform.position = randomPosition;

        //eyeBossMoveSpeedMultiplier = eyeBossStartMoveSpeedMultiplier;
        aiPath.maxSpeed = eyeBossStartMoveSpeed;
        isEyeClosedMoving = true;
        aiDestination.target = randomPositionTransform;
        //dirToRandomPosition = randomPosition - transform.position;

        //rb.MovePosition(rb.position + dirToRandomPosition.normalized * eyeBossMoveSpeed * eyeBossMoveSpeedMultiplier * Time.fixedDeltaTime);

	}

    void EyeOpenedMovement()
	{
        isEyeClosedMoving = false;
        aiDestination.target = player;
        aiPath.maxSpeed = eyeBossStartMoveSpeed + 0.5f;
        //eyeBossMoveSpeedMultiplier = eyeBossStartMoveSpeedMultiplier + 0.2f;

        //rb.MovePosition(rb.position + dirPlayer.normalized * eyeBossMoveSpeed * eyeBossMoveSpeedMultiplier * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, player.position) <= 2f)
        {
            player.GetComponent<PlayerHealth>().PlayerGetsDamage(damage);
        }
    }

    public void Rage()
	{
        damage += 15;
        //eyeBossMoveSpeed += 2f;
        aiPath.maxSpeed += 2f;
        eyeBossStartMoveSpeed = aiPath.maxSpeed;
	}

    private void OnDestroy()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyGO in enemy)
        {
            enemyGO.GetComponent<EyeBossMovement>().Rage();
            enemyGO.GetComponent<EyeBoss>().Rage2();
        }
    }
}
