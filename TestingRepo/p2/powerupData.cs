using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "powerupData", menuName = "powerupData", order = 1)]
public class powerupData : ScriptableObject {
	public string powerupName;
	public float duration;
	public GameObject model;
	public int effect;
}
