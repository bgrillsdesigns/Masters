using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    //Puzzle vars
    
    public bool isComplete = false;
    public Camera puzzlecam;
    public Camera playercam;
    protected GameObject puzzle;

    public float distanceToItem;
    protected Inventory inventory;
    protected Animator animator;
    protected bool highlight;

    public Renderer item;
    //Put Keyboard Panel Use in this
    public GameObject KeyboardPanel;
    //Put Controller Panel Use in this
    public GameObject ControllerPanel;
    //Tick this box if you want to toggle and object
    public bool isTrigger;
    //This is the object toggled
    public GameObject trigger;
    public GameObject HUD_Image;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
//commented out code was ommited here 
        playercam.gameObject.SetActive(true);
        puzzlecam.gameObject.SetActive(false);
    }
    void Update()
    {
        Press();
    }



    //======SOLVING SLIDE PUZZLE=====
    //4 if else
    //Movement
    //Get input
    //Check if all 4 sides
    //Go with array


    private void Press()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //This casts a ray to see the item that you are looking at.
        if (Physics.Raycast(ray, out hit, distanceToItem))
        {
            if (isComplete && playercam.isActiveAndEnabled)
            {
                if (Input.GetButtonDown("Use"))
                {
                    playercam.gameObject.SetActive(false);
                    puzzlecam.gameObject.SetActive(true);
                }
            }
            if (puzzlecam.isActiveAndEnabled && Input.GetButtonDown("Escape"))
            {
                playercam.gameObject.SetActive(true);
                puzzlecam.gameObject.SetActive(false);
            }

            //Checks that inventory has an item and the object is usable on the object raycasted
            if (hit.collider.gameObject.tag == "Use Interactable" && inventory.isFull[0] == true)
            {

                if (isComplete)
                {
                    highlightOn();
                    if (Input.GetButtonDown("Use"))
                    {
                        playercam.gameObject.SetActive(false);
                        puzzlecam.gameObject.SetActive(true);
                    }
                    highlightOff();
                }
                if (puzzlecam.isActiveAndEnabled && Input.GetButtonDown("Escape"))
                {
                    playercam.gameObject.SetActive(true);
                    puzzlecam.gameObject.SetActive(false);
                }

                //This highlights the object
                highlightOn();
                //waits for Use Button and Checks if you are holding a key
                if (Input.GetButtonDown("Use") && inventory.slots[0].name.StartsWith("piece"))
                {
                    string pieceval = inventory.slots[0].name;
                    pieceval = pieceval.Substring(5);

                    //Activate added piece in puzzle
                    puzzle = GameObject.Find("Level_Blocking/Sliding_Puzzle/slide_puzzle/piece" + pieceval + "_placed");
                    puzzle.SetActive(true);
                    isComplete = true;

                    GameObject.Find("Level_Blocking/Sliding_Puzzle").tag = "Puzzle";

                    //Cleans up the HUD and Inventory. Call this whenever you are using an object
                    useCleanup();
                    //unhighlights the item
                    highlightOff();
                }

                else
                {
                    //turns off the highlight when no longer looking at the object
                    highlightOff();
                }
            }
        }
    }



    protected void highlightOff()
    {
        if (highlight)
        {
            //reverts the shader back to standard
            item.material.shader = Shader.Find("Standard");
            //tracks if the item is no long highlighted
            highlight = false;
            //This statement is add to load the Pickup HUD text -- only here for convence
            if (inventory.controller == false)
                KeyboardPanel.SetActive(false);
            else if (inventory.controller == true)
                ControllerPanel.SetActive(false);
        }
    }
    protected void highlightOn()
    {
//commented out code was ommited here 
        if (highlight == false)
        {
            //tracks if the items is highlight
            highlight = true;
            //finds the shader for the outline and turns it on
            item.material.shader = Shader.Find("Please Outline");
            //This statement is add to load the Pickup HUD text -- only here for convence
            if (inventory.controller == false)
                KeyboardPanel.SetActive(true);
            else if (inventory.controller == true)
                ControllerPanel.SetActive(true);
        }
    }
    protected IEnumerator wait(RaycastHit hit)
    {
//commented out code was ommited here 
        //This waits for the animation to be done
        yield return new WaitForSeconds(2);
        //This hides the object used, this fixes when there is two of the same 
        //objects you need to interact with, put the second in trigger and toggle is trigger.
        hit.collider.gameObject.SetActive(false);
        yield break;

    }
    protected void useCleanup()
    {
        //Gets rid of slot 1's object
        inventory.slots[0] = null;
        //Clears sprite off HUD
        HUD_Image.SetActive(false);
        //Sets the inventory spot to empty
        inventory.isFull[0] = false;
    }
    protected void swapMesh(GameObject A, GameObject B)
    {
        Mesh intMesh = A.GetComponent<MeshFilter>().mesh;
        Mesh swapMesh;
        GameObject target;

        target = A;
        intMesh = A.GetComponent<MeshFilter>().mesh;
        swapMesh = B.GetComponent<MeshFilter>().mesh;

        target.GetComponent<MeshFilter>().mesh = swapMesh;
    }
}
