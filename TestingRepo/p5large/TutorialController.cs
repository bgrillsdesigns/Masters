using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialController : MonoBehaviour {
    public bool neverDone = true;
    public int doTutorial = 0;
    public bool buttonClicked = false; 
    public bool walkingTutorial = false;
    public bool lookingTutorial = false;
    public bool pickupTutorial = false;
    public bool useTutorial = false;
    public bool crouchTutorial = false; 
    private GameObject player;
    public GameObject tutorialControllerScreen;
    public GameObject pauseController;
    //public GameObject controller;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void doTutorialController()
    {
        doTutorial = 1; 
    }

    public void doNotDoTutorialController()
    {
        doTutorial = 2; 
    }

    public void buttonClickedController()
    {
        buttonClicked = true; 
    }

    private void Start()
    {
        neverDone = true;
        walkingTutorial = false;
        lookingTutorial = false;
        pickupTutorial = false;
        useTutorial = false;
        crouchTutorial = false;

        if (PlayerPrefs.GetInt("Tutorial") != 2)
        {
            tutorialControllerScreen.SetActive(true);
            Time.timeScale = 0f;
            pauseController.SetActive(false);
        }

    }
    // Use this for initialization
    private void Update()
    {
       // player = GameObject.FindGameObjectWithTag("Player");
        if (buttonClicked == true)
        {
            Time.timeScale = 1f; 
        }
        //neverDone = true;
        //doTutorial = false;
        //walkingTutorial = false;
        //lookingTutorial = false;
        //pickupTutorial = false;
        //useTutorial = false;

        //int counter = 0; 

        //controller.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //while (neverDone == true)
        //{
        //controller.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        //if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        //{

        //if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        //{
        //    Time.timeScale = 1f;
        //}

        if (doTutorial == 1)
        {


            if (walkingTutorial == false && (Input.GetKey(KeyCode.W) || Input.GetAxisRaw("Vertical") != 0))
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                walkingTutorial = true;
                //Debug.Log("finished walking tutorial");
            }

            if (walkingTutorial == true && lookingTutorial == false && Input.GetAxisRaw("X") != 0)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                lookingTutorial = true;
            }

            var inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

            if (lookingTutorial == true && pickupTutorial == false && inventory.isFull[0] == true)
            {
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                gameObject.transform.GetChild(4).gameObject.SetActive(true);
                pickupTutorial = true;
            }

            if (pickupTutorial == true && useTutorial == false && inventory.isFull[0] == false)
            {
                gameObject.transform.GetChild(4).gameObject.SetActive(false);
                gameObject.transform.GetChild(5).gameObject.SetActive(true);
                useTutorial = true;
            }

            if (useTutorial == true && Input.GetButtonDown("crouch"))
            {
                gameObject.transform.GetChild(5).gameObject.SetActive(false);

                crouchTutorial = true;
            }

            pauseController.SetActive(true);

        }

        else if (doTutorial == 2)
        {
            pauseController.SetActive(true); 
        }

           // }
        //}
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
