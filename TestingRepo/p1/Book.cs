using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {
    public int bookNumber;
    public GameObject obj;
    public string display;
    
	// Use this for initialization
	
    public int GetBookNum()
    {
        return bookNumber;
    }
	
    public void setBookNum(int num)
    {
        bookNumber = num;
    }

    public bool Puzzle()
    {
        if (obj.transform.parent.gameObject.GetComponent<Book_Manager>().UseBook(bookNumber))
        {
            // play animation on book for tiliting it
            obj.GetComponent<Book_Animator>().SetPositions(obj, true);
            
            if (obj.transform.parent.gameObject.GetComponent<Book_Manager>().CheckSolution())
            {

                if (obj.transform.parent.gameObject.GetComponent<Book_Manager>().Solve())
                {
                    // Spawn key
                    obj.transform.parent.gameObject.GetComponent<Book_Manager>().FinishPuzzle();
                    obj.transform.parent.gameObject.GetComponent<LibraryPuzzleReset>().ClearColliders();

                    return true;
                }

                else
                {
                    obj.transform.parent.gameObject.GetComponent<Book_Manager>().Reset();

                    obj.transform.parent.gameObject.GetComponent<LibraryPuzzleReset>().ResetPositions();

                }
            }
           
        }

        return false;

    }

    public void DisplayText(bool toDisplay)
    {
        if(toDisplay)
            obj.transform.parent.gameObject.GetComponent<Book_Manager>().ChangeText(display);
        else
            obj.transform.parent.gameObject.GetComponent<Book_Manager>().ChangeText("");

    }
}
