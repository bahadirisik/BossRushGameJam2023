using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    
    public void PortalSpawn()
	{
        Instantiate(portal,Vector3.zero,Quaternion.identity);
	}
}
