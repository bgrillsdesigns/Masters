using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class powerup : MonoBehaviour {

	public powerupData data;
		private float duration;
		private int effect;

	// Animation
		// Animation Controls
		public float degreesPerSecond = 15.0f;
		public float amplitude = 0.5f;
		public float frequency = 1f;

		// Position Variables
		Vector3 posOffset = new Vector3 ();
		Vector3 tempPos = new Vector3 ();
 
	void Start () {
		duration = data.duration;
		effect = data.effect;
		posOffset = transform.position;
	}

	void Update(){
		// Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
 
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
	}
	
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Debug.Log("youre in the powerup");
			pickup(other);
		}
	}

	void pickup(Collider player){
		if (effect == 0){
			StartCoroutine(speedPowerup(player));
		}
		else if (effect == 1){
			StartCoroutine(shotPowerup(player));
		}
		else{
			Debug.Log("Unknown Powerup");
			Destroy(gameObject);
		}
	}

	IEnumerator speedPowerup(Collider player){
		shootController shotStats = player.GetComponent<shootController>();
		PlayerController playerStats = player.GetComponent<PlayerController>();

		shotStats.timeBetweenShots /= 2;
		playerStats.walkSpeed *= 2;

		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		yield return new WaitForSeconds(duration);

		playerStats.walkSpeed /= 2;
		shotStats.timeBetweenShots *= 2;
		Destroy(gameObject);
	}

	IEnumerator shotPowerup(Collider player){
		shootController shotStats = player.GetComponent<shootController>();

		shotStats.numShots += 2;

		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		yield return new WaitForSeconds(duration);

		shotStats.numShots -= 2;
		Destroy(gameObject);
	}
}

// Floater v0.0.2
// by Donovan Keith
// [MIT License](<a href="https://opensource.org/licenses/MIT">https://opensource.org/licenses/MIT</a>)
 
