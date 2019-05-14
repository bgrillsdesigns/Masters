using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyStats : MonoBehaviour {

	public StatAbility data;
	public float duration;
	public int healthIncrease;
	public int shotIncrease;
	public float fireRateMod;
	public float damageMod;
	public float walkSpeedMod;
	public int healthDiff;

	private GameObject particleSystem;
//commented out code was ommited here 
	private PlayerStats healthStats;
	private shootController shootStats;
	private PlayerController moveStats;

	void Start () {
//commented out code was ommited here 
		//Eventually might need to change this to look for children of other

    	duration = data.duration;
		healthIncrease = data.healthIncrease;
		shotIncrease = data.shotIncrease;
		fireRateMod = data.fireRateMod;
		damageMod = data.damageMod;
		walkSpeedMod = data.walkSpeedMod;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Debug.Log("Hit the applier");
			Debug.Log(other);
			healthStats = other.GetComponent<PlayerStats>();
			Debug.Log(healthStats);
    		shootStats = other.GetComponent<shootController>();
			moveStats = other.GetComponent<PlayerController>();
//commented out code was ommited here 
			GetComponent<Collider>().enabled = false;
			StartCoroutine("Modify");
		}
	}

	IEnumerator Modify()
    {
//commented out code was ommited here 
//commented out code was ommited here 
    	if (healthStats.currentHealth + healthIncrease < healthStats.maxHealth){
			healthStats.currentHealth +=  healthIncrease;
		}
		else {
			healthDiff = healthStats.maxHealth - healthStats.currentHealth;
			//Cases to increase fire rate
			if (healthDiff < 10){
				fireRateMod = 2.0F;
			}
			else if (healthDiff < 25){
				fireRateMod = 1.5F;
			}
			else if (healthDiff < 35){
				fireRateMod = 1.3F;
			}
			else{
				fireRateMod = 1F;
			}
			healthStats.currentHealth = healthStats.maxHealth;

		}

		shootStats.numShots += shotIncrease;
		shootStats.timeBetweenShots /= fireRateMod;
		moveStats.walkSpeed *= walkSpeedMod;

		Debug.Log("ShotSpeed: " + shootStats.timeBetweenShots);


		yield return new WaitForSecondsRealtime(duration);

		shootStats.numShots -= shotIncrease;
		shootStats.timeBetweenShots *= fireRateMod;
		moveStats.walkSpeed /= walkSpeedMod;

		Debug.Log("ShotSpeed After: " + shootStats.timeBetweenShots);

//commented out code was ommited here 
    	Destroy(gameObject);
		StopCoroutine ("Modify");
    }
}
