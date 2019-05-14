﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {


    public string interactButton;

    public float interactDistance = 3f;

    public LayerMask interactLayer;

    public Image interactIcon; //Picture to show if interaction is allowed on item

    public bool isInteracting;

    public GameObject playerObject;

    // Use this for initialization
    void Start ()
    {
        if(interactIcon != null)
        {
            interactIcon.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if (isInteracting == false)
            {
                if (interactIcon != null)
                {
                    interactIcon.enabled = true;
                }
                if (Input.GetButtonDown(interactButton))
                {
                    ////Add all interactables here!!
                    //if(hit.collider.CompareTag("Note"))
                    //{
//commented out code was ommited here 
                    //}
                }
            }
        }
        else
        {
            interactIcon.enabled = false;
        }
	}
}
