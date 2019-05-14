using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSelection : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject currentObject;
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject settingsButton;
    public GameObject mainMenuButton;
    public GameObject controlsButton;
    public GameObject backButton;
    public GameObject saveButton;
    public GameObject aboutButton;
    public GameObject restartButton;
    public GameObject checkpointButton; 

    public bool isPauseMenu;
    public bool isHelpMenu;
    public bool isSettingsMenu;
    public bool isMainMenuMenu;
    public bool isDeathMenu; 

    private bool isCurrentButton;
    private bool isResume;
    private bool isQuit;
    private bool isSettings;
    private bool isMainMenu;
    private bool isControls;
    private bool isBackButton;
    private bool isSaveButton;
    private bool isAboutButton;
    private bool isRestartButton;
    private bool isCheckpointButton; 


    // Used to keep the controller from endlessly cycling through the buttons.
    private bool currentlyMoving = false; 

	// Use this for initialization
	void Start () {
        isCurrentButton = false;
        isResume = false;
        isQuit = false;
        isSettings = false;
        isMainMenu = false;
        isControls = false; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isPauseMenu == true)
        {
            if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == false)
            {
                if (currentlyMoving == false)
                {
                    eventSystem.SetSelectedGameObject(currentObject);
                    isCurrentButton = true;
                    isResume = true;
                    currentlyMoving = true;
                }
            }

            else if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == true)
            {
                if (currentlyMoving == false)
                {
                    if (isResume == true)
                    {
                        Debug.Log("isResume is true");
                        eventSystem.SetSelectedGameObject(mainMenuButton);
                        isMainMenu = true;
                        isResume = false;
                        isSettings = false;
                        isControls = false;
                        isRestartButton = false;
                        isQuit = false;
                    }

                    else if (isMainMenu == true)
                    {
                        Debug.Log("isMainMenu is true");
                        eventSystem.SetSelectedGameObject(controlsButton);
                        isMainMenu = false;
                        isResume = false;
                        isSettings = false;
                        isControls = true;
                        isRestartButton = false;
                        isQuit = false;
                    }

                    else if (isControls == true)
                    {
                        Debug.Log("IsControls is true");
                        eventSystem.SetSelectedGameObject(settingsButton);
                        isMainMenu = false;
                        isResume = false;
                        isSettings = true;
                        isControls = false;
                        isRestartButton = false;
                        isQuit = false;
                    }

                    else if (isSettings == true)
                    {
                        Debug.Log("isSettings is true");
                        eventSystem.SetSelectedGameObject(restartButton);
                        isMainMenu = false;
                        isResume = false;
                        isSettings = false;
                        isControls = false;
                        isRestartButton = true; 
                        isQuit = false;
                    }

                    else if (isRestartButton == true)
                    {
                        Debug.Log("isRestartButton is true");
                        eventSystem.SetSelectedGameObject(quitButton);
                        isMainMenu = false;
                        isResume = false;
                        isSettings = false;
                        isControls = false;
                        isRestartButton = false;
                        isQuit = true;
                    }

                    else if (isQuit == true)
                    {
                        Debug.Log("isQuit is true");
                        eventSystem.SetSelectedGameObject(resumeButton);
                        isMainMenu = false;
                        isResume = true;
                        isSettings = false;
                        isControls = false;
                        isRestartButton = false;
                        isQuit = false;
                    }

                    currentlyMoving = true;
                }
            }

            if (Input.GetAxisRaw("Vertical") == 0)
            {
                currentlyMoving = false;
            }
        }

        else if (isHelpMenu == true)
        {

            eventSystem.SetSelectedGameObject(currentObject);
            isCurrentButton = true;
            isBackButton = true;
            currentlyMoving = true;

        }

        else if (isSettingsMenu == true)
        {
            if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == false)
            {
                if (currentlyMoving == false)
                {
                    eventSystem.SetSelectedGameObject(currentObject);
                    isCurrentButton = true;
                    isSaveButton = true;
                }
            }

            else if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == true)
            {
                if (currentlyMoving == false)
                {
                    if (isSaveButton == true)
                    {
                        eventSystem.SetSelectedGameObject(backButton);
                        isBackButton = true;
                        isSaveButton = false;
                    }

                    else if (isBackButton == true)
                    {
                        eventSystem.SetSelectedGameObject(saveButton);
                        isBackButton = false;
                        isSaveButton = true;
                    }
                    currentlyMoving = true;
                }
            }

            if (Input.GetAxisRaw("Vertical") == 0)
            {
                currentlyMoving = false;
            }

        }

        else if (isMainMenuMenu == true)
        {
            if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == false)
            {
                if (currentlyMoving == false)
                {
                    eventSystem.SetSelectedGameObject(currentObject);
                    isCurrentButton = true;
                    isResume = true;
                    currentlyMoving = true;
                }
            }

            else if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == true)
            {
                if (currentlyMoving == false)
                {
                    if (isResume == true)
                    {
                        eventSystem.SetSelectedGameObject(controlsButton);
                        isResume = false;
                        isControls = true;
                        isSettings = false;
                        isAboutButton = false;
                        isQuit = false;
                        currentlyMoving = true;
                    }

                    else if (isControls == true)
                    {
                        eventSystem.SetSelectedGameObject(settingsButton);
                        isResume = false;
                        isControls = false;
                        isSettings = true;
                        isAboutButton = false;
                        isQuit = false;
                        currentlyMoving = true;
                    }

                    else if (isSettings == true)
                    {
                        eventSystem.SetSelectedGameObject(aboutButton);
                        isResume = false;
                        isControls = false;
                        isSettings = false;
                        isAboutButton = true;
                        isQuit = false;
                        currentlyMoving = true;
                    }

                    else if (isAboutButton == true)
                    {
                        eventSystem.SetSelectedGameObject(quitButton);
                        isResume = false;
                        isControls = false;
                        isSettings = false;
                        isAboutButton = false;
                        isQuit = true;
                        currentlyMoving = true;
                    }

                    else if (isQuit == true)
                    {
                        eventSystem.SetSelectedGameObject(resumeButton);
                        isResume = true;
                        isControls = false;
                        isSettings = false;
                        isAboutButton = false;
                        isQuit = false;
                        currentlyMoving = true;
                    }
                }


            }

            if (Input.GetAxisRaw("Vertical") == 0)
            {
                currentlyMoving = false;
            }
        }

        else if (isDeathMenu == true)
        {
//commented out code was ommited here 
            if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == false)
            {
                if (currentlyMoving == false)
                {
                    eventSystem.SetSelectedGameObject(currentObject);
                    isCurrentButton = true;
                    isCheckpointButton = true;
                    currentlyMoving = true;
                }
            }


            else if (Input.GetAxisRaw("Vertical") != 0 && isCurrentButton == true)
            {
                if (currentlyMoving == false)
                {
                    if (isCheckpointButton == true)
                    {
//commented out code was ommited here 
                        eventSystem.SetSelectedGameObject(mainMenuButton);
                        isMainMenu = true;
                        isCheckpointButton = false;

                    }

                    else if (isMainMenu == true)
                    {
//commented out code was ommited here 
                        eventSystem.SetSelectedGameObject(checkpointButton);
                        isCheckpointButton = true;
                        isMainMenu = false;

                    }
                    currentlyMoving = true; 
                }

            }
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            currentlyMoving = false;
        }

    }

    private void OnDisable()
    {
        isCurrentButton = false;
        isResume = false;
        isQuit = false;
        isSettings = false;
        isMainMenu = false;
        isControls = false;
        isBackButton = false;
        isSaveButton = false;
}
}
