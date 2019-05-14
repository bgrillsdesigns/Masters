using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class BallManager : MonoBehaviour {

	public int scoreRed;
	public int scoreBlue;
	public int goal;
	public TextMeshProUGUI GameWin;
	public TextMeshProUGUI RedText;
	public TextMeshProUGUI BlueText;
    public GameObject[] players;
    public Transform redSpawn;
    public Transform blueSpawn;

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Goal1")
		{
			//got compenent and get team.
			//then look at the network spawn positions
			scoreRed += 1;
			SetScoreRed();
			StartCoroutine("ResetScene");
		}
			

		if (other.gameObject.tag == "Goal2")
		{  
			scoreBlue += 1;
			SetScoreBlue();
			StartCoroutine("ResetScene");
		}

	}


	IEnumerator ResetScene(){
		if (scoreBlue >= 3)
		{
			Time.timeScale = 0;
		}
		else if (scoreRed >= 3)
		{
			Time.timeScale = 0;
		}

        players = GameObject.FindGameObjectsWithTag("Player");

        if (players != null) {
        	players[0].transform.position = redSpawn.position;
        	//Disabling the player and reseting their stats
        	players[0].GetComponent<shootController>().enabled = false;       	   	
			players[0].GetComponent<PlayerController>().enabled = false;
		}

        if (players.Length > 2) {
          	players[1].transform.position = blueSpawn.position;   
          	players[1].GetComponent<shootController>().enabled = false;
			players[1].GetComponent<PlayerController>().enabled = false; 
		}  	
        
        //reset the ball location
		transform.position = GameObject.Find("BallPosition").transform.position;
		this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;


		//dispaly a countdown
		for(int i = 5; i > 0; i--){
			GameWin.text = i.ToString();
			yield return new WaitForSeconds(1);
		}

		GameWin.text = "";
		//allow the players to control again
        if (players != null) {
        	players[0].GetComponent<shootController>().enabled = true;
			players[0].GetComponent<PlayerController>().enabled = true;
         	players[0].GetComponent<shootController>().Reset();
         	players[0].GetComponent<PlayerController>().Reset(); 
          	players[0].GetComponent<PlayerStats>().Reset();   
		}

        if (players.Length > 2) {
          	players[1].transform.position = blueSpawn.position;   
          	players[1].GetComponent<shootController>().enabled = true;
			players[1].GetComponent<PlayerController>().enabled = true; 
			players[1].GetComponent<shootController>().Reset();
         	players[1].GetComponent<PlayerController>().Reset();  
         	players[1].GetComponent<PlayerStats>().Reset();  
		}

	}

	void SetScoreBlue()
	{
		BlueText.text = scoreBlue.ToString();
		if (scoreBlue >= 3)
		{
			GameWin.text = "Game Over - BLUE WINS!";
		}
	}

	void SetScoreRed()
	{
		RedText.text = scoreRed.ToString();
		if (scoreRed >= 3)
		{
			GameWin.text = "Game Over - RED WINS!";
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void Start() {
	}
}
