using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPuzzle : MonoBehaviour {
    public NumberSlot[] slotList = new NumberSlot[5];
    public Sprite[] spriteList = new Sprite[10];

    private bool solved = false;
    public GameObject puzzle;

	// Use this for initialization
	void Start () {
		for(int x = 0; x < 5; x++)
        {
            slotList[x].GetComponentsInChildren<Image>()[1].sprite = spriteList[0];
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!solved)
        {
            if (slotList[0].value == 2 && slotList[1].value == 4 && slotList[2].value == 1 && slotList[3].value == 8 && slotList[4].value == 9)
            {
                solved = true;
                puzzle.GetComponent<Animator>().Play("CigarBoxAnimation");                
                puzzle.GetComponent<BoxCollider>().enabled = false;
                puzzle.GetComponent<SpawnItemEvent>().SpawnItemLighter();
            }
        }

    }

   

    public void UpdateLock(int num)
    {
        slotList[num].UpdateValuePlus();
       
    }

    public void UpdateSprite(int num)
    {
        slotList[num].GetComponentsInChildren<Image>()[1].sprite = spriteList[slotList[num].GetValue()];
    }
}
