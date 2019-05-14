using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
    public float speed;
    public float walk = 10.0f;
    public float sprint = 15.0f;

    public static bool hidden_player = false;
    private float translation;
    private float straffe;
    public GameObject flashLight;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        speed = walk;
	}
	
	// Update is called once per frame
	void Update () {
        translation = Input.GetAxis("Vertical");
        straffe = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift) && translation > 0){
            speed = sprint;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = walk;
            }
  
        translation = translation * speed * Time.deltaTime;
        straffe = straffe * speed * Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("f"))
        {
            if(flashLight.activeInHierarchy)
                flashLight.GetComponent<FlashLight_Controller>().LightOff();

            else
                flashLight.GetComponent<FlashLight_Controller>().LightOn();



        }
    }
}
