using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class nameboxText : MonoBehaviour {
	public characterData data;

	private TextMeshProUGUI characterName;
	void Start () {
		characterName = GetComponent<TextMeshProUGUI>();
		characterName.text = data.characterName;
	}
	
	void Update () {
		
	}
}
