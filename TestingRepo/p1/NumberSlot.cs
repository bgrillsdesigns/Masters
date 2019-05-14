using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSlot : MonoBehaviour {
    public int value;

	// Use this for initialization
	void Start () {
        value = 0;
	}
	
    public void UpdateValuePlus()
    {
        if (value < 9)
            value++;
        else
            value = 0;

        Debug.Log(value);
            
    }

    public int GetValue()
    {
        return value;
    }
	
}
