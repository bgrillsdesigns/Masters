using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Book_Manager : MonoBehaviour
{
    private bool[] bookList = new bool[5];
    public int[] bookOrder = new int[5];
    public int[] solution = new int[5];
    public int[] solution2 = new int[5];

    public bool solved = false;

    public GameObject key;
    public GameObject gunpart;
    public GameObject obj;
    public GameObject resetButton;


    // Use this for initialization
    void Start()
    {
        bookList[0] = false;
        bookList[1] = false;
        bookList[2] = false;
        bookList[3] = false;
        bookList[4] = false;

        bookOrder[0] = 10;
        bookOrder[1] = 10;
        bookOrder[2] = 10;
        bookOrder[3] = 10;
        bookOrder[4] = 10;

        solution[0] = 2;
        solution[1] = 4;
        solution[2] = 1;
        solution[3] = 5;
        solution[4] = 3;

        solution2[0] = 3;
        solution2[1] = 1;
        solution2[2] = 5;
        solution2[3] = 4;
        solution2[4] = 2;

    }

    public bool CheckSolution()
    {
        bool toSolve = false;

        for(int a = 0; a < 5; a++)
        {
            if (bookList[a])
                toSolve = true;
            else
                return false;
        }

        return toSolve;
    }

    public bool UseBook(int bookNum)
    {
        if (bookList[bookNum - 1])
        {
            return false;
        }

        else
        {
            // animation will be played from Player_Pickup script with a true value returned
            bookList[bookNum - 1] = true;
            
                for (int i = 0; i < 5; i++)
                {
                    if (bookOrder[i] == 10)
                    {
                        bookOrder[i] = bookNum;
                    return true;
                    }
                }
            

            return true;
        }

        
    }

    public bool Solve()
    {

        if (!solved)
        {
            for (int i = 0; i < 5; i++)
            {

                // When it returns true the Player_Pickup script will call Solved() function.
                if (solution[i] != bookOrder[i])
                    return false;
            }
        }
        else
        {
            // Checks for the second part of the puzzle and then checks the soluton presented
            for (int i = 0; i < 5; i++)
            {

                // When it returns true the Player_Pickup script will call Solved() function.
                if (solution2[i] != bookOrder[i])
                    return false;
            }
        }

        if (!solved)
        {
            resetButton.SetActive(true);
        }

        return true;
    }

    public void Reset()
    {
        // called when all books have been pulled and CheckSolution returns a false
        // also needs to reset book positions

        bookList[0] = false;
        bookList[1] = false;
        bookList[2] = false;
        bookList[3] = false;
        bookList[4] = false;

        bookOrder[0] = 10;
        bookOrder[1] = 10;
        bookOrder[2] = 10;
        bookOrder[3] = 10;
        bookOrder[4] = 10;
    }

    public void FinishPuzzle()
    {
        if (!solved)
        {
            key.SetActive(true);
            key.GetComponent<SpawnItemEvent>().SpawnItemKey();
        }
        else
        {
            gunpart.SetActive(true);
        }
    }

    public void ChangeText(string text)
    {
        obj.GetComponent<MessageTimer>().textBox.GetComponent<Text>().text = text;
        obj.GetComponent<MessageTimer>().ResetTimer();
        
    }
}