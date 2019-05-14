using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = 10.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 3.0F;
    private Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

    // Use this for initialization
    void Start () {

        controller = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Rotate Player
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

    }
}
