using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampLava : MonoBehaviour
{
    private float moveSpeed = 8f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	private void FixedUpdate()
	{
        rb.MovePosition(rb.position + Vector2.down * moveSpeed * Time.fixedDeltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().PlayerGetsDamage(10);
            Destroy(gameObject);
        }
    }
}
