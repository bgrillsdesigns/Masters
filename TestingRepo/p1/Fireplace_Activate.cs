using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace_Activate : MonoBehaviour {
    public GameObject fire;

	public void TurnOn()
    {
        fire.SetActive(true);
    }

    public void TurnOff()
    {
        fire.SetActive(false);
    }
}
