using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchController : MonoBehaviour {

    public CharacterController characterController;
    bool isCrouched = false; 
    // Use this for initialization
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("crouch") && isCrouched == false)
        {
            isCrouched = true;
            characterController.height = 1f;
        }
        else if (Input.GetButtonDown("crouch") && isCrouched == true)
        {
            characterController.height = 1.8f;
            isCrouched = false; 
        }
	}
}
