using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using TMPro;

public class PlayerStats : NetworkBehaviour {
	public characterData data;
	// Health stats
	public int currentHealth;
	public int maxHealth;

	public Image healthFill;
	public Text healthTextDisplay;
	public TextMeshProUGUI gameText;

    public Transform redSpawn;
    public Transform blueSpawn;
    public Transform spawnPoint;

    public GameObject player;
    public GameObject skin;

//commented out code was ommited here 

	// Team
	public int team;

	public void Awake(){
		if(team == 0){
			GetComponentInChildren<SpriteRenderer>().color = Color.red;
		}
		else{
			GetComponentInChildren<SpriteRenderer>().color = Color.blue;
		}	
	}


	// Use this for initialization
	void Start () {
		currentHealth = data.health;
		maxHealth = data.health;

		
		PlayerStats cont = GetComponent<PlayerStats>();
		healthFill = cont.healthFill;
		healthTextDisplay = cont.healthTextDisplay;
		redSpawn = cont.redSpawn;
		blueSpawn = cont.blueSpawn;
		gameText = cont.gameText;

		//this is for testing since team isnt't fully implemented
//commented out code was ommited here 

		if (team == 1){
			spawnPoint = redSpawn;
		}
		else {
			spawnPoint = blueSpawn;
		}

		player = this.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0){
			StartCoroutine("Died");
//commented out code was ommited here 
		}
		//Need to place a respawn mechanic here
		float CH = Mathf.Round (currentHealth);
		float MH = Mathf.Round (maxHealth);
		healthFill.fillAmount = CH/MH;
		healthTextDisplay.text = currentHealth.ToString() + "/" + maxHealth.ToString();
	}

	public void TakeDamage(int damage){
		Debug.Log(transform.name + " now has " + currentHealth + " health");
		currentHealth -= damage;
		if(currentHealth < 0){
			currentHealth = 0;
		}
	}

	public void Reset() {
		currentHealth = maxHealth;
	}

	IEnumerator Died(){
		GetComponent<PlayerController>().enabled = false;
		GetComponent<shootController>().enabled = false;
		skin.SetActive(false);

		yield return new WaitForSeconds(3);

		currentHealth = maxHealth;
		GetComponent<PlayerController>().enabled = true;
		GetComponent<shootController>().isFiring = false;
		GetComponent<shootController>().enabled = true;
		GetComponent<shootController>().Reset();
   		GetComponent<PlayerController>().Reset(); 
		skin.SetActive(true);


	}

	// IEnumerator Respawn(){
//commented out code was ommited here 

	// 	gameText.GetComponent<TextMeshProUGUI>().color = new Color32(195,0,54,255);
	// 	gameText.text = "YOU DIED";
	// 	//Hiding the player
	// 	skin.SetActive(false);

	// 	//Disabling the player and reseting their stats
	// 	player.GetComponent<shootController>().enabled = false;        	   	
	// 	player.GetComponent<PlayerController>().enabled = false;
	// 	yield return new WaitForSeconds(3);

	// 	gameText.GetComponent<TextMeshProUGUI>().color = new Color32(229,212,217,255);

	// 	//move the player
    //     player.transform.position = spawnPoint.position;
    //     skin.SetActive(true);
    //     gameText.text = "Ready";
	// 	yield return new WaitForSeconds(1);
	// 	gameText.text = "Go";
	// 	yield return new WaitForSeconds(1);
		


	// 	gameText.text = "";

    //     player.GetComponent<shootController>().enabled = true;        	   	
	// 	player.GetComponent<PlayerController>().enabled = true;
	// 	player.GetComponent<shootController>().Reset();
    //     player.GetComponent<PlayerController>().Reset(); 
	// 	Reset();
		

	// }
}
