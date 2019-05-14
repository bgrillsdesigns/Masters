using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionProjectile : MonoBehaviour {

	public Transform target;
	public Vector3 realTarget;
	
	public int team;

	public int damage;

	public float speed;

	void Update(){
		transform.position = Vector3.MoveTowards(transform.position, realTarget, speed * Time.deltaTime);
	}


	void Start () {
		damage = 8;
		realTarget = new Vector3(target.position.x, target.position.y, target.position.z);
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Minion") && other.gameObject.GetComponent<Stats>().team != team){
			other.gameObject.GetComponent<Stats>().TakeDamage(damage);
			Debug.Log(other.gameObject.name + " took " + damage);
			Destroy(gameObject);	
		}
		else if (other.gameObject.CompareTag("Player")){
			other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);	
			Destroy(gameObject);
		}
	}
}
