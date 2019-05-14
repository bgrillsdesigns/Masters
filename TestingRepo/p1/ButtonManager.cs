using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public Button b0, b1, b2, b3, b4;
    public NumberPuzzle Puzzle;

	// Use this for initialization
	void Start () {
        b0.onClick.AddListener(() => TaskOnClick(0));
        b1.onClick.AddListener(() => TaskOnClick(1));
        b2.onClick.AddListener(() => TaskOnClick(2));
        b3.onClick.AddListener(() => TaskOnClick(3));
        b4.onClick.AddListener(() => TaskOnClick(4));
    }
	
    void TaskOnClick(int num)
    {
        Debug.Log("You just clicked button " + num);
        Puzzle.UpdateLock(num);
        Puzzle.UpdateSprite(num);
    }
	
}
