using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Stats : NetworkBehaviour {


	[SerializeField]
	public float maxHealth = 100;

	public float health;

	public int team;

	public void Awake(){
		health = maxHealth;
	}

	
	public void LateStart(int t){

		team = t;

		if(t == 0){
			GetComponentInChildren<SpriteRenderer>().color = Color.red;
			GetComponent<Minion>().LateStart(team);
		}
		else if(t == 1){
			GetComponentInChildren<SpriteRenderer>().color = Color.blue;
			GetComponent<Minion>().LateStart(team);
		}
	}
	public void TakeDamage(float damage){
		Mathf.Clamp(damage, 0, Mathf.Infinity);

		health -= damage;
	}

	public void Update(){
		if (health <= 0){
			Die();
		}
	}

	public void Die(){
		Destroy(gameObject);
	}
}
