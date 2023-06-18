using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] abilities;

    float minX = -16f;
    float minY = -8f;
    void Start()
    {
        StartCoroutine(SpawnAbility());
    }

    IEnumerator SpawnAbility()
	{
        yield return new WaitForSeconds(5f);

        Vector3 randomPosition = new Vector3(Random.Range(minX,-minX), Random.Range(minY, -minY),0f);

        GameObject abilityGO = Instantiate(abilities[Random.Range(0,abilities.Length)],randomPosition,Quaternion.identity);
        Destroy(abilityGO,7f);

        yield return new WaitForSeconds(17f);

        StartCoroutine(SpawnAbility());
    }
}
