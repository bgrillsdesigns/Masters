using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : NetworkBehaviour {

	private GameObject model;
	public characterData data;
	public float walkSpeed;

	private Quaternion targetRotation;
	private CharacterController controller;
	public Camera cam;
	public Camera minimapCam;
	Ray cameraRay;
	RaycastHit cameraRayHit;

	public GameObject PlayerCanvas;
	
	void Awake () {
		controller = GetComponent<CharacterController>();
		cam = Camera.main;
		minimapCam = GameObject.FindGameObjectWithTag("minimapCamera").GetComponent<Camera>();
		walkSpeed = data.walkSpeed;

	}
	
	void FixedUpdate () {
		if(this.isLocalPlayer){
			mouseControl();
		}
	}

	void mouseControl(){
		cameraRay = cam.ScreenPointToRay(Input.mousePosition);
		Plane groundplane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;
		if(groundplane.Raycast(cameraRay, out rayLength)){
			Vector3 pointToLook = cameraRay.GetPoint(rayLength);
			transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}

		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		Vector3 motion = input;

		motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)?.7f:1;
		motion *= walkSpeed;
		motion += Vector3.up * -8;

		controller.Move(motion * Time.deltaTime);
	}

	public override void OnStartLocalPlayer(){
        Camera.main.GetComponent<gameCamera>().setTarget(gameObject.transform);
		minimapCam.GetComponent<gameCamera>().setTarget(gameObject.transform);
		base.OnStartLocalPlayer();
		gameObject.name = "localPlayer";
		if(isLocalPlayer){
			PlayerCanvas.SetActive(true);
		}
     }

	public void OnControllerColliderHit(ControllerColliderHit other){
		if(other.gameObject.tag == "Bullet"){
			Debug.Log("You ran into a bullet");
			
			
		}
		else if (other.gameObject.tag == "Wall"){
			Debug.Log("Theres a wall there");
		}
	}

	public void Reset() 
	{
		walkSpeed = data.walkSpeed;
	}
}
