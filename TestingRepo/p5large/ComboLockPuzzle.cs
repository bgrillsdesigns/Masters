using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboLockPuzzle : MonoBehaviour {
    public GameObject FPSControllerCam;
    public GameObject PuzzleCam;
    public GameObject HUD;
    public GameObject Puzzle_HUD;
    public GameObject[] Tumblers;
    public GameObject Trigger;
    public bool Done;
    public int[] CurrentPuzzle;
    public int[] CompletedPuzzle;
    public GameObject CurrentPosition;
    public int x;
    private int Count;
    private bool Entered;

    private AudioSource audioSource;
    private AudioClip SlideSound;
    private GameObject GameController;


    private void Awake()
    {
        audioSource = GameObject.Find("Effects Player").GetComponent<AudioSource>();
        SlideSound = Resources.Load<AudioClip>("Sounds/SlideSound");
        GameController = GameObject.Find("GameController");

        CurrentPosition = Tumblers[0];
        x = 0; Done = false; Entered = true;
    }
    void Update()
    {
        if (!Done && CurrentPuzzle[Count] == CompletedPuzzle[Count])
            Count++;
        else if (!Done && CurrentPuzzle[Count] != CompletedPuzzle[Count])
            Count = 0;
        if (Count == 4)
        {
            Done = true;
            //GameController.GetComponent<Save>().SaveGame();
            PuzzleEnd();
        }
        if (!Done) ComboPress();
        else { PuzzleEnd(); Trigger.SetActive(false); }
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
    public void ComboPress()
    {
        if (Input.GetKeyDown("a") && x != 0)
        {
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            CurrentPosition = Tumblers[x-1]; x--;
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Please Outline");
        }
        else if (Input.GetKeyDown("d") && x != 3)
        {
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            CurrentPosition = Tumblers[x + 1]; x++;
            CurrentPosition.GetComponent<MeshRenderer>().material.shader = Shader.Find("Please Outline");
        }

        if (Input.GetButtonDown("Use"))
        {
            if (x == 0)
            {
                CurrentPuzzle[0] = (CurrentPuzzle[0] + 1) % 10;


            }
            else if (x == 1)
            {
                CurrentPuzzle[1] = (CurrentPuzzle[1] + 1) % 10;

            }
            else if (x == 2)
            {
                CurrentPuzzle[2] = (CurrentPuzzle[2] + 1) % 10;

            }
            else if (x == 3)
            {
                CurrentPuzzle[3] = (CurrentPuzzle[3] + 1) % 10;

            }
        }
        else if (Input.GetKeyDown("r")) PuzzleEnd();
    }
    public void PuzzleEnd()
    {
        FPSControllerCam.SetActive(true); this.enabled = false; PuzzleCam   .SetActive(false);
    }
    public void PlaySound()
    {
        audioSource.volume = 1F;

        audioSource.clip = SlideSound;
        audioSource.Play();
    }
}

