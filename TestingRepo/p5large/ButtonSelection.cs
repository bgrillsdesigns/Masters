using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour {
    

    public EventSystem eventSystem; // Set in the Unity Editor
    public List<int> indexList; // Only public because functions cannot access it otherwise. 
    private bool isMoving = false; 
    private int childCount = 0;
    private int currentCount = 0;  
    private readonly string searchTag = "menuButton";

    // Use this for initialization
    void Start () {
        GetButtons();
	}
	
	// Update is called once per frame
	void Update () {

        // Checks if the user tries to select the next button. isMoving prevents multiple jumps at one time. 
        if (currentCount < childCount)
        {
            if (Input.GetAxisRaw("Vertical") != 0 && isMoving == false)
            {
                eventSystem.SetSelectedGameObject(gameObject.transform.GetChild(indexList[currentCount]).gameObject);
                currentCount++;
                isMoving = true; 
            }

            if(Input.GetButtonDown("Submit"))
            {
                eventSystem.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke(); 
            }
        }
  
        else
        {
            // Resets to the beginning when it reaches the last button 
            currentCount = 0; 
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            isMoving = false;
        }
    }

    // Loops through all the children of the current gameobject, adding the indexes of each that match the search tag
    private void GetButtons()
    {
        Transform child;
        int maxCount = gameObject.transform.childCount;
        for(int i =0; i < maxCount; i++)
        {
            child = gameObject.transform.GetChild(i);

            if(child.tag == searchTag)
            {
                //Debug.Log(child.name);
                indexList.Add(i);
                childCount++; 
            }
        }
    }
}
