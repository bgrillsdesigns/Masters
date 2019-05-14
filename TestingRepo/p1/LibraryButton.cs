using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryButton : MonoBehaviour {

    public GameObject lib;
    public GameObject self;


    public void EnablePart2()
    {
        lib.GetComponent<Book_Manager>().Reset();
        lib.GetComponent<Book_Manager>().solved = true;
        lib.GetComponent<LibraryPuzzleReset>().EnableColliders();
        lib.GetComponent<LibraryPuzzleReset>().ResetPositions();

        self.GetComponent<BoxCollider>().enabled = false;

    }
}
