using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPool : MonoBehaviour {
    public int team;

    void Update () {
        Destroy(gameObject, 15); 
    }

    void Start () {
        GameObject player = GameObject.Find("localPlayer");
        this.team = player.GetComponent<PlayerStats>().team;
    }

	private void OnTriggerEnter(Collider other)
    {
        PlayerStats oStats = other.gameObject.GetComponent<PlayerStats>();
    	if (other.gameObject.tag == "Player" && this.team != oStats.team){ //&& other.gameObject.GetComponent<PlayerStats>.team != this.team){
        	StartCoroutine ("Poison", other);
    	}
        // else if (other.gameObject.tag == "Minion"){
        //     other.gameObject.StartCoroutine("PoisonMin");
        // }
    }

    private void OnTriggerExit(Collider other)
    {
    	if (other.gameObject.tag == "Player"){
    		StopCoroutine ("Poison");
    	}
        // else if (other.gameObject.tag == "Minion"){
        //     StopCoroutine ("Exterminate");
        // }
    }

    IEnumerator Poison(Collider character)
    {
        PlayerStats stats = character.GetComponent<PlayerStats>();


    	for (int currentHealth = stats.currentHealth; currentHealth > 3; currentHealth -= 3){
			stats.currentHealth = currentHealth;
            //controls the rate at which the player is healed
			yield return new WaitForSeconds (1);
		}

		stats.currentHealth = 0;
    }

    // IEnumerator Exterminate(Collider minion)
    // {
    //     Debug.Log("Poisining minions");
    //     Stats mStats = minion.GetComponent<Stats>();

    //     for (float health = mStats.health; health > 4; health -= 4){
    //         mStats.health = health;
    //         yield return new WaitForSeconds (1);
    //     }

    //     mStats.health = 0;
    // }
}
