using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField] private GameObject drop;
    [SerializeField] private GameObject dropEnd;
    [SerializeField] private GameObject deathEffect;

    Rigidbody2D rb;

    Collider2D coll;

    Vector3 startPosition;
    Vector3 endPosition;
    Vector2 dir;

    private bool isArrived = false;

    float minX = -16f;
    float minY = -8f;
    float moveSpeed = 10f;
    void Start()
    {
        isArrived = false;
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        float randomX = Random.Range(minX,-minX);
        float randomY = Random.Range(minY,-minY);
        startPosition = new Vector3(randomX,20f,0f);
        endPosition = new Vector3(randomX,randomY,0f);

        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,endPosition) <= 0.2f)
		{
            deathEffect.SetActive(true);
            drop.SetActive(false);
            dropEnd.SetActive(true);
            GetComponent<TrailRenderer>().enabled = false;
            isArrived = true;
            coll.enabled = true;
            Destroy(gameObject, 3f);
		}

        dir = endPosition - startPosition;
    }

	private void FixedUpdate()
	{
        if (isArrived)
            return;

        rb.MovePosition(rb.position + dir.normalized * moveSpeed * Time.fixedDeltaTime);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
            collision.GetComponent<PlayerHealth>().PlayerGetsDamage(10);
            Destroy(gameObject);
		}
	}
}
