using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace S3

{

	public class CelloController : NetworkBehaviour 
	{

		[SyncVar]
		public string pname = "player";
		[SyncVar]
		public Color playerColor = Color.white;

		public GameObject bulletPrefab;
		public Transform bulletSpawn;
	

	void OnGUI()
	{
		if (isLocalPlayer)
		{
			pname = GUI.TextField (new Rect (25, Screen.height - 40, 100, 30), pname);
			if(GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
			{
				CmdChangeName(pname);
			}
		}
	}

	[Command]
	public void CmdChangeName(string newName)
	{
		pname = newName;
		this.GetComponentInChildren<TextMesh>(). text = pname;
	}

	void Start()
	{
		/*if(isLocalPlayer)
		{
			Renderer[] rends = GetComponentInChildren<Renderer[]>();
			foreach (Renderer r in rends)
			r.material.color = playerColor;
		}*/
	}


		// Update is called once per frame
		void Update () 
		{
			if(!isLocalPlayer)
			{
				return;
			}
		
			float x= Input.GetAxis("Horizontal") * Time.deltaTime * 120.0f;
			float z= Input.GetAxis("Vertical") * Time.deltaTime * 20.0f;

			transform.Rotate(0, x, 0);
			transform.Translate(0, 0, z);

			if(Input.GetKeyDown(KeyCode.Space))
			{
				Fire();
			}

		}

		void Fire()
		{
			//Create the bullet for Cello
			GameObject bullet = (GameObject) Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

			//Add velocity to the bullet
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 25.0f;

			//Destroy the bullet afetr 2 seconds
			Destroy(bullet, 2);
		}

		public override void OnStartLocalPlayer()
		{
			GetComponent<MeshRenderer>().material.color = Color.white;
		}
	}

}
