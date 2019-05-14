using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletController : MonoBehaviour {

	// public Character data;
	public characterData data;
	public float speed;

	public int team;

	void Start () {
		//Need to make this not rely on specific SO
		speed = data.shotSpeed;
	}

	public void setTeam(int t){
		team = t;
	}

	void Awake(){
		
	}
	
	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		Destroy(gameObject, 3);	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Minion") && other.gameObject.GetComponent<Stats>().team != team){
			other.gameObject.GetComponent<Stats>().TakeDamage(data.baseDamage);
			Destroy(gameObject);	
		}
		else if (other.gameObject.CompareTag("Player")){
			other.gameObject.GetComponent<PlayerStats>().TakeDamage(data.baseDamage);	
			Destroy(gameObject);
		}
	}

	// void showDamageText(){ 
	// 	Instantiate(floatingText, transform.position, Quaternion.identity);
	// }
}