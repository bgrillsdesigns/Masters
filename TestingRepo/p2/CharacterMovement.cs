using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody myRB;
	private Vector3 movementVect;
	public float movementSpeed = 5f;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody> ();
		movementVect = new Vector3();
	}
	
	// Update is called once per frame. Good for looking for inputs
	void Update () {
		movementVect = new Vector3(Input.GetAxisRaw("Horizontal") * movementSpeed, myRB.velocity.y, Input.GetAxisRaw("Vertical") * movementSpeed);
	}

	// Update on physics related object, this should be used more than update for better framerate. Better to handle inputs
	void FixedUpdate () {
		myRB.velocity = movementVect;
	}
}
