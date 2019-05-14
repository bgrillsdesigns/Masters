using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactPrompt : MonoBehaviour {

    public GameObject guiObject;

    // Use this for initialization
    void Start () {
        guiObject.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
        }

    }

    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
