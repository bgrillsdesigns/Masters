using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Image noteImage;
    public GameObject hideNoteButton;
    public GameObject note;
    public GameObject takeButton;

    public AudioClip pickUpSound;
    public AudioClip putAwaySound;

    public GameObject player;

    private bool inInventory;
    // Use this for initialization
    void Start ()
    {
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);
        takeButton.SetActive(false);
        inInventory = false;
    }
	
    public void ShowNoteImage()
    {
        noteImage.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(pickUpSound);
        hideNoteButton.SetActive(true);

        if (!inInventory)
        {
            takeButton.SetActive(true);

            player.GetComponent<Character_Controller>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;
            player.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().enabled = false;
            player.transform.GetChild(0).GetComponent<Headbobber>().enabled = false;
            Cursor.lockState = CursorLockMode.None;

            player.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().CursorDisplay();
        }
    }

    public void HideNoteImage()
    {
        noteImage.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);
        hideNoteButton.SetActive(false);

        if (!inInventory)
        {
            takeButton.SetActive(false);

            player.GetComponent<Character_Controller>().enabled = true;
            player.GetComponent<PlayerController>().enabled = true;
            player.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().enabled = true;
            player.transform.GetChild(0).GetComponent<Headbobber>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            player.GetComponent<PlayerController>().enabled = true;

            player.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().NoCursorDisplay();
        }
    }

    public void TakeNote()
    {
        HideNoteImage();
        note.GetComponent<Pickup_Item>().Pickup();
        inInventory = true;
    }
}
