using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

	int count = 0;
	public GameObject LoadingCanvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count == 90){
			LoadingCanvas.SetActive(false);
			count = 0;
		}

	}
}
