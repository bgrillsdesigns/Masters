using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	 bool pause;
	 bool menu;

	public GameObject pauseCanvas;
	public GameObject inventoryCanvas;
	public GameObject optionsCanvas;
	public GameObject skillCanvas;
	public GameObject menuCanvas;
	public GameObject craftingCanvas;
	public Button inventoryButton;
	public Button closeButton;
	public Button skillButton;
	public Button optionsButton;
	public Button inventoryReturnButton;
	public Button skillReturnButton;
	public Button optionsReturnButton;
	public Button craftingButton;
	public Button craftingReturnButton;
	
	void Start () {
		inventoryButton.onClick.AddListener(inventoryButtonAction);
		skillButton.onClick.AddListener(skillButtonAction);
		optionsButton.onClick.AddListener(optionsButtonAction);
		closeButton.onClick.AddListener(closeButtonAction);
		inventoryReturnButton.onClick.AddListener(inventoryReturnButtonAction);
		skillReturnButton.onClick.AddListener(skillReturnButtonAction);
		optionsReturnButton.onClick.AddListener(optionsReturnButtonAction);
		craftingButton.onClick.AddListener(craftingButtonAction);
		craftingReturnButton.onClick.AddListener(craftingReturnButtonAction);
	}
	// Update is called once per frame
	void Update () {
		if(pause){
			pauseCanvas.SetActive(true);
			Time.timeScale = 0f;
			if(menu){
				menuCanvas.SetActive(true);
				inventoryCanvas.SetActive(false);
				optionsCanvas.SetActive(false);
				skillCanvas.SetActive(false);
				craftingCanvas.SetActive(false);
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			pause = true;
			menu = true;
		}
	}

	public void inventoryButtonAction(){
		menu = false;
		menuCanvas.SetActive(false);
		inventoryCanvas.SetActive(true);
	}
	public void closeButtonAction(){
		menuCanvas.SetActive(false);
		menu = false;
		pause = false;
		Time.timeScale = 1f;
	}
	public void skillButtonAction(){
		menu = false;
		menuCanvas.SetActive(false);
		skillCanvas.SetActive(true);
	}
	public void optionsButtonAction(){
		menu = false;
		menuCanvas.SetActive(false);
		optionsCanvas.SetActive(true);
	}
	public void craftingButtonAction(){
		menu = false;
		menuCanvas.SetActive(false);
		craftingCanvas.SetActive(true);
	}

	public void inventoryReturnButtonAction(){
		menu = true;
	}
	public void skillReturnButtonAction(){
		menu = true;
	}
	public void optionsReturnButtonAction(){
		menu = true;
	}
		public void craftingReturnButtonAction(){
		menu = true;
	}
}
