using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimpFly : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    Vector2 dir;
    float speed = 10f;

    float randomX;
    float randomY;
    void Start()
    {
        randomX = Random.Range(-1f,1f);
        randomY = Random.Range(-1f,1f);

        dir = new Vector2(randomX,randomY);

        rb.AddForce(dir.normalized * speed,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,5f);
    }
}
