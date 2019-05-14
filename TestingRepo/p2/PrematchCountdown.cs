using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrematchCountdown : MonoBehaviour 
{
	private GameManagerScript GMS;

	public void SetCountDownNow()
	{
		GMS = GameObject.Find ("GameManager").GetComponent <GameManagerScript>();
		GMS.countDown = true;
	}
}

