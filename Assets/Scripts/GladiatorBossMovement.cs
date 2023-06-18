using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorBossMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    float startBossMoveSpeed = 25f;
    float startBossMoveSpeedMultiplier = 0.2f;
    [SerializeField] private float bossMoveSpeedMultiplier;
    [SerializeField] private float bossMoveSpeed;
    private float disToThePlayer;

    public bool isAttacking = false;
    public bool bossAttack2 = false;

    [SerializeField] private Transform bossAttackTransform;

    private Vector2 dirPlayer;
    private Vector2 centerDir;
    private Rigidbody2D rb;
    void Start()
    {
        bossAttack2 = false;
        isAttacking = false;
        rb = GetComponent<Rigidbody2D>();
        bossMoveSpeed = startBossMoveSpeed;
        bossMoveSpeedMultiplier = startBossMoveSpeedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        disToThePlayer = Vector3.Distance(player.position,transform.position);

        dirPlayer = player.position - transform.position;
        centerDir = bossAttackTransform.position - transform.position;
    }

	private void FixedUpdate()
	{
		if (bossAttack2)
		{
            rb.MovePosition(rb.position + centerDir * bossMoveSpeed * bossMoveSpeedMultiplier * Time.fixedDeltaTime);
		}

        if (isAttacking || disToThePlayer <= 1f)
		{
            return;
		}

        rb.MovePosition(rb.position + dirPlayer.normalized * bossMoveSpeed * bossMoveSpeedMultiplier * Time.fixedDeltaTime);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
            collision.GetComponent<PlayerHealth>().PlayerGetsDamage(20);
		}
	}

    public void Bos()
	{

	}
}
