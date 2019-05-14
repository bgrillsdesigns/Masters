using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPuzzleReset : MonoBehaviour {

    public GameObject[] bookList = new GameObject[5];


    public void ResetPositions()
    {
        for(int i = 0; i < 5; i++)
        {
            bookList[i].GetComponent<Book_Animator>().SetPositions(bookList[i], false);

        }
    }

    public void ClearColliders()
    {
        for(int i = 0; i < 5; i++)
        {
            bookList[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void EnableColliders()
    {
        for (int i = 0; i < 5; i++)
        {
            bookList[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
}
