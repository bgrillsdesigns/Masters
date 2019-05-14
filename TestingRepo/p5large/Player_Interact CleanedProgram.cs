using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Interact : MonoBehaviour
{
    private float DistanceToItem = 10f;
    private Inventory inventory;
    public RaycastHit hit;
    private Renderer HighlightedItem;
    private bool highlight;
    public GameObject KeyboardPanel, ControllerPanel;
//commented out code was ommited here 
    // Use this for initialization
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        highlight = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, DistanceToItem))
        {
            if (hit.collider.gameObject.tag == "Item Interactable" && inventory.isFull[0] == false)
            {
                HUD_PopupOn(); HighlightOn(hit);
                hit.collider.GetComponent<Pickup>().Collect(hit);
            }
            else if (hit.collider.gameObject.tag == "Use Interactable" && inventory.isFull[0] == true)
            {
                HUD_PopupOn(); HighlightOn(hit);
                hit.collider.GetComponent<Use>().Press(hit);

            }
            else if (Input.GetButtonDown("Use") && hit.collider.gameObject.tag == "Puzzle")
            {
                hit.collider.GetComponent<SlidingPuzzle>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
                hit.collider.GetComponent<SlidingPuzzle>().PuzzleCam.SetActive(true);
            }
            else if (Input.GetButtonDown("Use") && hit.collider.gameObject.tag == "Combo_Lock")
            {
                hit.collider.GetComponent<ComboLockPuzzle>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
                hit.collider.GetComponent<ComboLockPuzzle>().PuzzleCam.SetActive(true);
            }
            else if (hit.collider.gameObject.tag == "Plugger" && !hit.collider.gameObject.GetComponent<plugger>().Pushed && hit.collider.gameObject.GetComponent<plugger>().Wire.activeInHierarchy)
            {
                HUD_PopupOn(); HighlightOn(hit);
                hit.collider.GetComponent<plugger>().Down(hit);
            }
            else if (hit.collider.gameObject.tag == "Door")
            {
                HUD_PopupOn();
                if(Input.GetButtonDown("Use"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                HUD_PopupOff(); HighlightOff(hit); HighlightedItem = null; highlight = false;
            }
        }

    }
    public void HUD_PopupOn()
    {
        if (inventory.controller == false)
            KeyboardPanel.SetActive(true);
        else if (inventory.controller == true)
            ControllerPanel.SetActive(true);
    }
    public void HUD_PopupOff()
    {
        if (inventory.controller == false)
            KeyboardPanel.SetActive(false);
        else if (inventory.controller == true)
            ControllerPanel.SetActive(false);
    }
    public void HighlightOn(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag == "Item Interactable")
        {
//commented out code was ommited here 
            HighlightedItem = hit.collider.GetComponent<Pickup>().PickupRenderer; highlight = true;
        }
        else if (hit.collider.gameObject.tag == "Use Interactable")
        {
            HighlightedItem = hit.collider.GetComponent<Use>().UseRenderer; highlight = true;
        }
        else if (hit.collider.gameObject.tag == "Plugger")
        {
            HighlightedItem = hit.collider.GetComponent<plugger>().PluggerRenderer; highlight = true;
        }
        HighlightedItem.material.shader = Shader.Find("Please Outline");

    }
    public void HighlightOff(RaycastHit hit)
    {
        if (highlight)
            HighlightedItem.material.shader = Shader.Find("Standard");
    }
}
