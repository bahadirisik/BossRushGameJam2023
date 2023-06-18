using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Rigidbody2D rb;

    float ballSpeed = 10f;
    int maxBounce = 5;

    Vector3 randomDir;
    Vector3 lastVelocity;
    void Start()
    {
        maxBounce = 6;
        rb = GetComponent<Rigidbody2D>();
        randomDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);

        rb.AddForce(randomDir.normalized * ballSpeed,ForceMode2D.Impulse);
    }

    void Update()
    {
        if(maxBounce <= 0)
		{
            Destroy(gameObject);
		}

        lastVelocity = rb.velocity;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if(collision.collider.tag == "Player")
		{
            collision.collider.gameObject.GetComponent<PlayerHealth>().PlayerGetsDamage(15);
            Destroy(gameObject);
        }

        maxBounce -= 1;
        ballSpeed = lastVelocity.magnitude;
        Vector3 dir = Vector3.Reflect(lastVelocity.normalized,collision.GetContact(0).normal);

        rb.velocity = dir * ballSpeed;
	}
}
