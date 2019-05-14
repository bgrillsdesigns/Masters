using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public Renderer PickupRenderer;
    public GameObject HUD_Image;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {

    }
    //pick's up item you are looking at if tagged interactable.
    public void Collect(RaycastHit hit)
    {
        if (hit.collider.gameObject.name == "Gasmask" && Input.GetButtonDown("Use"))
        {
            inventory.slots[1] = hit.collider.gameObject;
            hit.collider.gameObject.SetActive(false);
        }
        else if (Input.GetButtonDown("Use"))
        {
            pickupcontroller(hit);
            hit.collider.gameObject.SetActive(false);
        }
    }
    public void pickupcontroller(RaycastHit hit)
    {
        //This is storing the gameObject in the inventory
        inventory.slots[0] = hit.collider.gameObject;
        //This stores the name of the gameObject in the collected list
        inventory.list[inventory.count] = hit.collider.gameObject.name;
        //Moves the list to the next postion
        inventory.count++;
        //Sets the inventory slot to full
        inventory.isFull[0] = true;
        //Activate the HUD image added to the item
        HUD_Image.SetActive(true);
    }
}
