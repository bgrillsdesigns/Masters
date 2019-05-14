using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
	double Health;
	public GameObject Life0;
	public GameObject Life1;
	public GameObject Life2;
	public GameObject Life3;
	public GameObject Life4;
	public GameObject Life5;
	public GameObject Life6;
	public GameObject Life7;
	private playerController player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player").GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
		Health = player.CheckHealthPoints();
		if (Health == 4){
			Life7.SetActive(true);
			Life6.SetActive(false);
			Life5.SetActive(false);
			Life4.SetActive(false);
			Life3.SetActive(false);
			Life2.SetActive(false);
			Life1.SetActive(false);
			Life0.SetActive(false);
		}
		if (Health == 3.5){
			Life6.SetActive(true);
			Life7.SetActive(false);
			Life5.SetActive(false);
			Life4.SetActive(false);
			Life3.SetActive(false);
			Life2.SetActive(false);
			Life1.SetActive(false);
			Life0.SetActive(false);
		}
		if (Health == 3){
			Life5.SetActive(true);
			Life6.SetActive(false);
			Life7.SetActive(false);
			Life4.SetActive(false);
			Life3.SetActive(false);
			Life2.SetActive(false);
			Life1.SetActive(false);
			Life0.SetActive(false);
		}
		if (Health == 2.5){
			Life4.SetActive(true);
			Life6.SetActive(false);
			Life5.SetActive(false);
			Life7.SetActive(false);
			Life3.SetActive(false);
			Life2.SetActive(false);
			Life1.SetActive(false);
			Life0.SetActive(false);
		}
		if (Health == 2){
			Life3.SetActive(true);
			Life6.SetActive(false);
			Life5.SetActive(false);
			Life4.SetActive(false);
			Life7.SetActive(false);
			Life2.SetActive(false);
			Life1.SetActive(false);
			Life0.SetActive(false);
		}
		if (Health == 1.5){
			Life2.SetActive(true);
			Life6.SetActive(false);
			Life5.SetActive(false);
			Life4.SetActive(false);
			Life3.SetActive(false);
			Life7.SetActive(false);
			Life1.SetActive(false);
			Life0.SetActive(false);
		}
		if (Health == 1){
			Life1.SetActive(true);
			Life6.SetActive(false);
			Life5.SetActive(false);
			Life4.SetActive(false);
			Life3.SetActive(false);
			Life2.SetActive(false);
			Life7.SetActive(false);
			Life0.SetActive(false);
		}
		if (Health == .5){
			Life0.SetActive(true);
			Life6.SetActive(false);
			Life5.SetActive(false);
			Life4.SetActive(false);
			Life3.SetActive(false);
			Life2.SetActive(false);
			Life1.SetActive(false);
			Life7.SetActive(false);
		}
	}
}
