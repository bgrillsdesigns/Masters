using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float health = 100; //start with 100 health
	public GameObject explosionPrefab;

	private AudioSource audioSource;
	public AudioClip Scored;

	// Use this for initialization
	void Start () {
	
	}


	void OnCollisionEnter(Collision collision)
	{
		//if the object hitting this ball is a bullet..  then do everything between curly brackets
		if (collision.gameObject.tag == "bullet")
		{
			health -= 25; //reduce health by 25 (so it only takes FOUR hits to destroy object)

//commented out code was ommited here 

			if(health<0){ //if health is 0 or less then destroy object
			
				audioSource = GetComponent<AudioSource>(); 
				audioSource.clip = Scored;
				audioSource.Play(); //play explosion sound


				GameObject explosion = Instantiate(explosionPrefab); //make a new explosion container with a copy of the particle effect we selected
				
				explosion.transform.position = gameObject.transform.position; //move the explosion object to the same psotion as the ball

				Destroy(explosion, 2); //remove the particle effect after 2 seconds

				Destroy(gameObject,2); //remove the ball after health reaches zero
			}
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
