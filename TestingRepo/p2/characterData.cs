using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "characterData", menuName = "Character", order = 1)]
public class characterData : ScriptableObject {

	// Rendering
	// public GameObject model;


	// Identification
	public string characterName;
	public int characterID;


	// Speed
	public float walkSpeed;
	// public float speed;
	public float shotSpeed;
	public float attackSpeed;
	// public float range;

	//Bullet Modifiers
	public int numShots;

	public int baseDamage;
	// public int secondaryDamage;
	// public int ultimateDamage;


	// Resources
	public int health;


	// Abilities
	public Ability[] abilities;
}
