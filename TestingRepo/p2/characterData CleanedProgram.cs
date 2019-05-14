using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "characterData", menuName = "Character", order = 1)]
public class characterData : ScriptableObject {

	// Rendering
//commented out code was ommited here 


	// Identification
	public string characterName;
	public int characterID;


	// Speed
	public float walkSpeed;
//commented out code was ommited here 
	public float shotSpeed;
	public float attackSpeed;
//commented out code was ommited here 

	//Bullet Modifiers
	public int numShots;

	public int baseDamage;
//commented out code was ommited here 
//commented out code was ommited here 


	// Resources
	public int health;


	// Abilities
	public Ability[] abilities;
}
