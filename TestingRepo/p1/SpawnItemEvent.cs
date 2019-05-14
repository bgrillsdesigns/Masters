using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemEvent : MonoBehaviour {
    public GameObject toSpawn;

	
    public void SpawnItemLighter()
    {
        toSpawn.GetComponent<BoxCollider>().enabled = true;
    }

    public void SpawnItemKey()
    {
        toSpawn.SetActive(true);
        toSpawn.GetComponent<SphereCollider>().enabled = true;
        
    }
}
