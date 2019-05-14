using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour {

	public Button newGame;
	// Use this for initialization
	void Start () {
		newGame.onClick.AddListener(NewGameAction);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NewGameAction(){
		SceneManager.LoadScene(0);
	}
}
