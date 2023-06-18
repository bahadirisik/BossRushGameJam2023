using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    float destroyingTime = 0.4f;
    [SerializeField]private Vector3 offset = new Vector3(0f,0.5f,0f);
    float moveYSpeed = 7f;
    void Start()
    {
        Destroy(gameObject,destroyingTime);

        transform.position += offset;
    }

	private void Update()
	{
        transform.position += new Vector3(0f,moveYSpeed) * Time.deltaTime;
	}

}
