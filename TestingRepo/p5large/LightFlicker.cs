using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public Light light; 

	// Use this for initialization
	void Start () {
        float minFlicker = 0.5f;
        float maxFlicker = 2.5f;
        float flickerSpeed = 0.035f; 
        int randomizer = 0;

        while(true)
        {
            if (randomizer == 0)
            {
                light.intensity = (Random.Range(minFlicker, maxFlicker));
            }

            else
            {
                light.intensity = (Random.Range(minFlicker, maxFlicker));
            }

            randomizer = Random.Range(0, 1);
            //yield WaitForSeconds(flickerSpeed);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
