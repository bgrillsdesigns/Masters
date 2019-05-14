using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/StatAbility")]
public class StatAbility : Ability {

	public float duration;
	public int healthIncrease;
	public int shotIncrease;
	public float fireRateMod;
	public float damageMod;
	public float walkSpeedMod;

	private Transform firePoint;
	//drops an instance of a game object to apply to the character
	public GameObject applier;


	public override void Initialize(Transform obj)
    {
    	firePoint = obj;

    }

	public override void TriggerAbility()
    {
    	GameObject item = (GameObject) Instantiate(applier, firePoint.position, Quaternion.identity);
    }


}

