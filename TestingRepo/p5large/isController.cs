using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isController : MonoBehaviour {
    //to determine input for controller/keyboard
    public bool controller;

    // Update is called once per frame
    void Update() {
        if (controller == false) {
            if (Input.GetJoystickNames().Length > 0)
            {
                Debug.Log("Xbox Controller being used");
                controller = true;
            }
        }
        else if(controller == true){
            if (Input.GetJoystickNames().Length == 0)
            {
                Debug.Log("Keyboard is being used");
                controller = false;
            }
        }
    }
}
