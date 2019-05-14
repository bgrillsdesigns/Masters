using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    private Save saveScript;

    public GameObject spawnPoint;

    private void Start()
    {
        saveScript = GameObject.Find("FPSController").GetComponent<Save>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Set New Spawn Point
            saveScript.UpdateCheckpoint(spawnPoint);

            //Each checkpoint can be hit only once
            gameObject.SetActive(false);
        }
    }
}
