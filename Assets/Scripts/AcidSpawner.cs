using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject acid;
    void Start()
    {
        StartCoroutine(SpawnAcid());
    }

    IEnumerator SpawnAcid()
	{
        yield return new WaitForSeconds(1f);
        Instantiate(acid);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnAcid());
	}
}
