using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzle : MonoBehaviour
{
    private Inventory inventory;
    public GameObject FPSController;
    public GameObject PuzzleCam;
    public GameObject HUD;
    public GameObject Puzzle_HUD;
    private bool Done;
    public GameObject[] CurrentPuzzle;
    public GameObject[] CompletedPuzzle;
    private GameObject CurrentPosition;
    private GameObject GhostPiece;
    private int x;
    private int Count;
    private bool Entered;
    public GameObject HUD_Image;
    private AudioSource audioSource;
    private AudioClip SlideSound;
    public GameObject Key;
    public GameObject Hint;


    private void Start()
    {
        inventory = FPSController.GetComponent<Inventory>();
    }
    private void Awake()
    {
        audioSource = GameObject.Find("Effects Player").GetComponent<AudioSource>();
        SlideSound = Resources.Load<AudioClip>("Sounds/SlideSound");

        CurrentPosition = CurrentPuzzle[0];
        GhostPiece = CurrentPuzzle[4];
        x = 0; Done = false; Entered = true;
    }
    void Update()
    {
        if (!Done && CurrentPuzzle[Count] == CompletedPuzzle[Count])
            Count++;
        else if (!Done && CurrentPuzzle[Count] != CompletedPuzzle[Count])
            Count = 0;
        if (Count == 12)
        {
            Done = true;
        }
        if (!Done) PuzzlePress();
        else { PuzzleEnd(); Key.SetActive(false); GiveKey(); }
    }
    private void OnEnable()
    {
        HUD.SetActive(false); Puzzle_HUD.SetActive(true); CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Please Outline");
    }
    private void OnDisable()
    {
        if (Entered)
        {
            HUD.SetActive(true);
            Puzzle_HUD.SetActive(false);
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        }
    }
    public void PuzzlePress()
    {
        if (Input.GetKeyDown("w") && CurrentPosition != CurrentPuzzle[0] && CurrentPosition != CurrentPuzzle[1] && CurrentPosition != CurrentPuzzle[2] && CurrentPuzzle[x - 3] != GhostPiece)
        {
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            CurrentPosition = CurrentPuzzle[x - 3];
            x = x - 3;
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Please Outline");
        }
        else if (Input.GetKeyDown("s") && CurrentPosition != CurrentPuzzle[9] && CurrentPosition != CurrentPuzzle[10] && CurrentPosition != CurrentPuzzle[11] && CurrentPuzzle[x + 3] != GhostPiece)
        {
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            CurrentPosition = CurrentPuzzle[x + 3]; x = x + 3;
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Please Outline");
        }
        else if (Input.GetKeyDown("a") && CurrentPosition != CurrentPuzzle[0] && CurrentPosition != CurrentPuzzle[3] && CurrentPosition != CurrentPuzzle[6] && CurrentPosition != CurrentPuzzle[9] && CurrentPuzzle[x - 1] != GhostPiece)
        {
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            CurrentPosition = CurrentPuzzle[x - 1]; x--;
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Please Outline");
        }
        else if (Input.GetKeyDown("d") && CurrentPosition != CurrentPuzzle[2] && CurrentPosition != CurrentPuzzle[5] && CurrentPosition != CurrentPuzzle[8] && CurrentPosition != CurrentPuzzle[11] && CurrentPuzzle[x + 1] != GhostPiece)
        {
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            CurrentPosition = CurrentPuzzle[x + 1]; x++;
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Please Outline");
        }
        if (Input.GetButtonDown("Use"))
        {
            if (x - 3 >= 0 && GhostPiece == CurrentPuzzle[x - 3])
            {
                Vector3 TempPosition = CurrentPuzzle[x].transform.position;
                CurrentPuzzle[x].transform.position = CurrentPuzzle[x - 3].transform.position;
                CurrentPuzzle[x - 3].transform.position = TempPosition;

                CurrentPuzzle[x - 3] = CurrentPuzzle[x];
                CurrentPuzzle[x] = GhostPiece;
                x = x - 3;

                PlaySound();
            }
            else if (x + 3 <= 11 && GhostPiece == CurrentPuzzle[x + 3])
            {
                Vector3 TempPosition = CurrentPuzzle[x].transform.position;
                CurrentPuzzle[x].transform.position = CurrentPuzzle[x + 3].transform.position;
                CurrentPuzzle[x + 3].transform.position = TempPosition;


                CurrentPuzzle[x + 3] = CurrentPuzzle[x];
                CurrentPuzzle[x] = GhostPiece;
                x = x + 3;

                PlaySound();
            }
            else if (x + 1 <= 11 && GhostPiece == CurrentPuzzle[x + 1] && CurrentPosition != CurrentPuzzle[2] && CurrentPosition != CurrentPuzzle[5] && CurrentPosition != CurrentPuzzle[8] && CurrentPosition != CurrentPuzzle[11])
            {
                Vector3 TempPosition = CurrentPuzzle[x].transform.position;
                CurrentPuzzle[x].transform.position = CurrentPuzzle[x + 1].transform.position;
                CurrentPuzzle[x + 1].transform.position = TempPosition;

                CurrentPuzzle[x + 1] = CurrentPuzzle[x];

                CurrentPuzzle[x] = GhostPiece;
                x = x + 1;

                PlaySound();
            }
            else if (x - 1 >= 0 && GhostPiece == CurrentPuzzle[x - 1] && CurrentPosition != CurrentPuzzle[0] && CurrentPosition != CurrentPuzzle[3] && CurrentPosition != CurrentPuzzle[6] && CurrentPosition != CurrentPuzzle[9])
            {
                Vector3 TempPosition = CurrentPuzzle[x].transform.position;
                CurrentPuzzle[x].transform.position = CurrentPuzzle[x - 1].transform.position;
                CurrentPuzzle[x - 1].transform.position = TempPosition;

                CurrentPuzzle[x - 1] = CurrentPuzzle[x];
                CurrentPuzzle[x] = GhostPiece;
                x = x - 1;

                PlaySound();
            }
        }
        else if (Input.GetKeyDown("r")) PuzzleEnd();
        if (Input.GetButtonDown("Hint"))
        {
            Hint.SetActive(true);
        }
        if (Input.GetButtonUp("Hint"))
        {
            Hint.SetActive(false);
        }
    }
    public void PuzzleEnd()
    {
        FPSController.SetActive(true); this.enabled = false; PuzzleCam.SetActive(false);
    }
    public void PlaySound()
    {
        audioSource.volume = 1F;

        audioSource.clip = SlideSound;
        audioSource.Play();
    }
    private void GiveKey()
    {
        //This is storing the gameObject in the inventory
        inventory.slots[0] = Key;
        //This stores the name of the gameObject in the collected list
        inventory.list[inventory.count] = Key.name;
        //Moves the list to the next postion
        inventory.count++;
        //Sets the inventory slot to full
        inventory.isFull[0] = true;
        //Activate the HUD image added to the item
        HUD_Image.SetActive(true);
    }
}
