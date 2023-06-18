using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Scorpion : MonoBehaviour
{
    private Transform player;

    [SerializeField] private AIDestinationSetter aiDestination;
    [SerializeField] private AIPath aiPath;

    [SerializeField] private GameObject grpx;
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;

        aiDestination.target = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        if(aiPath.desiredVelocity.x >= 0.01f)
		{
            grpx.transform.localScale = new Vector3(1f,1f,1f);
		}else if(aiPath.desiredVelocity.x <= -0.01f)
		{
            grpx.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerHealth>().PlayerGetsDamage(10);
        }
    }
}
