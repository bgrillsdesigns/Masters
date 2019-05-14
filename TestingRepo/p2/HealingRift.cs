using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRift : MonoBehaviour {
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
        Debug.Log("Spawner team: " + this.team);
        PlayerStats oStats = other.gameObject.GetComponent<PlayerStats>();
    	if (other.gameObject.tag == "Player" && this.team == oStats.team){
        	StartCoroutine ("Heal", other);
    	}
        else if (other.gameObject.tag == "Minion"){
            StartCoroutine ("Buff", other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
    	if (other.gameObject.tag == "Player"){
    		StopCoroutine ("Heal");
    	}
        else if (other.gameObject.tag == "Minion"){
            StopCoroutine ("Buff");
        }
    }

    IEnumerator Heal(Collider character)
    {
        PlayerStats stats = character.GetComponent<PlayerStats>();


    	for (int currentHealth = stats.currentHealth; currentHealth <= stats.maxHealth; currentHealth += 1){
			stats.currentHealth = currentHealth;
            //controls the rate at which the player is healed
			yield return new WaitForSeconds (1);
		}

		stats.currentHealth = stats.maxHealth;
    }

    //makes minions invincible while they are in the rift
    IEnumerator Buff(Collider minion)
    {
        Stats mStats = minion.GetComponent<Stats>();
        mStats.health = mStats.maxHealth;
        yield return new WaitForSeconds (1);
    }
}
