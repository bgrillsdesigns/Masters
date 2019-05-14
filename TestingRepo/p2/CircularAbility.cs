using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu (menuName = "Abilities/CircularAbility")]
public class CircularAbility : Ability {

	//attached to the circle should be OnTriggerEnter and OnTriggerExit for damage over time or healing/buff
	public GameObject circlePrefab;
	private Transform firePoint;
	//public float duration;
	//public int team;

	//as of right now, the prefab still will need a reference to the character class
	public override void Initialize(Transform obj)
    {
    	firePoint = obj;
    }

	public override void TriggerAbility()
    {
    	GameObject rift = (GameObject)Instantiate(circlePrefab, firePoint.position, Quaternion.identity);
		NetworkServer.Spawn(rift);
	}
}
