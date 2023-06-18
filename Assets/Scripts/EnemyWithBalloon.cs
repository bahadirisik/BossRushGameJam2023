using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyWithBalloon : MonoBehaviour
{
    private Transform player;

    private bool isExploding;

    [SerializeField] private AIDestinationSetter aiDestination;

    [SerializeField] private GameObject blownArea;
    void Start()
    {
        isExploding = false;
        player = FindObjectOfType<PlayerHealth>().transform;

        aiDestination.target = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        if (isExploding)
            return;

        if (Vector3.Distance(transform.position,player.position) <= 2f)
		{
            StartCoroutine(Explode());
		}

    }

    IEnumerator Explode()
	{
        isExploding = true;
        blownArea.SetActive(true);
        GetComponent<AIPath>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        yield return new WaitForSeconds(0.7f);

        if (Vector3.Distance(transform.position, player.position) <= 4.5f)
		{
            player.gameObject.GetComponent<PlayerHealth>().PlayerGetsDamage(15);
		}

        FindObjectOfType<AudioManager>().Play("BalloonPop");
        GetComponent<EnemyHealth>().EnemyTakeDamage(999);
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2f);
        Gizmos.DrawWireSphere(transform.position, 4.5f);
    }
}
