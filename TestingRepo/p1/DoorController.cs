using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject door;
    private static bool on = false;

    private void Update()
    {
        
    if(!on)
        Debug.Log("Playing Animation");
        door.GetComponent<Animator>().Play("New State");
        on = true;
    }
}
