using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonsAttack : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition1;
    Vector2 dir;

    Rigidbody2D rb;

    float balloonsSpeed = 5f;

    bool isArrived;
    void Start()
    {
        isArrived = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isArrived)
            return;

        if(Vector3.Distance(endPosition1, transform.position) <= 0.2f)
		{
            isArrived = true;
		}

        dir = endPosition1 - transform.position;
    }

	private void FixedUpdate()
	{
        if (isArrived)
            return;

        rb.MovePosition(rb.position + dir.normalized * balloonsSpeed * Time.fixedDeltaTime);
	}
}
