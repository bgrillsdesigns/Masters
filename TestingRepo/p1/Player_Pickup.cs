using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Pickup : MonoBehaviour
{
    private int ray_dist = 2;
    public Canvas inventory_menu, puzzle_menu;
    private bool showing = false, puz_show = false, noteUI = false;
    public player character;
    public GameObject gunCam;
    public Image interactIcon; //Picture to show if interaction is allowed on item

    public bool isInteracting;
    public bool showBook;

    private string lastNote;

    // Use this for initialization
    void Start()
    {
        inventory_menu.gameObject.SetActive(false);
        puzzle_menu.gameObject.SetActive(false);

        if (interactIcon != null)
        {
            interactIcon.enabled = false;
        }

        showBook = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayHit;
        Vector3 fd = transform.TransformDirection(Vector3.forward);

        if (Input.GetKeyDown("e") && puz_show == true && showing == false)
        {
            puzzle_menu.gameObject.SetActive(false);
            character.GetComponent<Character_Controller>().enabled = true;
            puz_show = false;
            character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().enabled = true;
            character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().NoCursorDisplay();

            Cursor.lockState = CursorLockMode.Locked;


        }

        else if (Physics.Raycast(transform.position, fd, out rayHit, ray_dist))
        {
            if (rayHit.collider.isTrigger)
            {
                if (isInteracting == false)
                {
                    if (interactIcon != null)
                    {
                        interactIcon.enabled = true;
                    }
                    if (!showBook)
                    {
                        if (rayHit.collider.CompareTag("Book"))
                        {
                            rayHit.collider.GetComponent<Book>().DisplayText(true);

                        }
                    }
                    if (rayHit.collider.CompareTag("Plaque"))
                    {

                        rayHit.collider.GetComponent<Plaque>().ChangeText();

                    }
                    if (rayHit.collider.CompareTag("Hide"))
                    {
                        rayHit.collider.GetComponent<Plaque>().ChangeText();
                    }

                    if (Input.GetKeyDown("e"))
                    {
                        if (rayHit.collider.CompareTag("Item"))
                        {
                            rayHit.collider.GetComponent<Pickup_Item>().Pickup();
                        }

                        else if (rayHit.collider.CompareTag("Puzzle"))
                        {
                            puzzle_menu.gameObject.SetActive(true);
                            character.GetComponent<Character_Controller>().enabled = false;
                            puz_show = true;
                            character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().CursorDisplay();
                            character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().enabled = false;
                            Cursor.lockState = CursorLockMode.None;
                        }

                        else if (rayHit.collider.CompareTag("UnlockedDoor"))
                        {
                            rayHit.collider.GetComponent<AudioSource>().Play();
                            rayHit.collider.GetComponent<RotateDoor>().Rotate();
                            rayHit.collider.GetComponent<BoxCollider>().enabled = false;
                        }
                        else if (rayHit.collider.CompareTag("Door"))
                        {
                            if (rayHit.collider.GetComponent<Use_Item>().Use_Item_Door() == true)
                            {
                                rayHit.collider.GetComponent<AudioSource>().Play();
                                rayHit.collider.GetComponent<RotateDoor>().Rotate();
                                rayHit.collider.GetComponent<BoxCollider>().enabled = false;
                            }
                        }
                        else if (rayHit.collider.CompareTag("Fireplace"))
                        {
                            if (rayHit.collider.GetComponent<Use_Item>().Use_Item_Lighter() == true)
                            {
                                Inventory.instance.UpdateSlotUI();
                            }

                        }
                        else if (rayHit.collider.CompareTag("Note") && puz_show == false)
                        {
                            lastNote = rayHit.collider.GetComponent<Pickup_Item>().item.display_name;
                            rayHit.collider.GetComponent<Note>().ShowNoteImage();
                            noteUI = true;

                        }

                        else if (rayHit.collider.CompareTag("Workbench"))
                        { 
                            rayHit.collider.GetComponent<Workbench>().WorkbenchSolve();
                            rayHit.collider.GetComponent<Workbench>().isSolved();

                        }

                        else if (rayHit.collider.CompareTag("Scrap"))
                        {

                            rayHit.collider.GetComponent<Pickup_Item>().Pickup();

                        }

                        else if (rayHit.collider.CompareTag("Gun"))
                        {

                            rayHit.collider.GetComponent<Pickup_Item>().Pickup();
                            gunCam.SetActive(true);
                        }
                        
                        else if (rayHit.collider.CompareTag("Book"))
                        {
                           showBook = rayHit.collider.GetComponent<Book>().Puzzle();
                        }

                        else if (rayHit.collider.CompareTag("Record"))
                        {
                            rayHit.collider.GetComponent<Pickup_Item>().Pickup();
                        }
                        else if (rayHit.collider.CompareTag("RecordPlayer"))
                        {
                            rayHit.collider.GetComponent<RecordPlayer>().RecordPlayerSolve();
                        }
                        else if (rayHit.collider.CompareTag("BookReset"))
                        {
                            rayHit.collider.GetComponent<LibraryButton>().EnablePart2();
                            showBook = false;
                        }
                        else if (rayHit.collider.CompareTag("Flashlight"))
                        {
                            rayHit.collider.GetComponent<Pickup_Item>().Pickup();
                        }
                    }

                }
            }
        }
        else
        { 
            interactIcon.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && puz_show == false)
            {
            if (noteUI == true)
            {
                if (Inventory.instance.IsItem(lastNote))
                    noteUI = false;
            }

            if (showing == false && noteUI == false)
                {
                    inventory_menu.gameObject.SetActive(true);
                    showing = true;
                    Time.timeScale = 0;
                    character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().enabled = false;
                    character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().CursorDisplay();

            }

            else
                {
                    inventory_menu.gameObject.SetActive(false);
                    showing = false;
                    Time.timeScale = 1;
                    character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().enabled = true;
                    character.transform.GetChild(0).GetComponent<Camera_Mouse_Look>().NoCursorDisplay();


            }
        }
        
       
    }
}
