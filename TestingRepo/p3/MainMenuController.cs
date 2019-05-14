using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;

    private float Vertical_Axis = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(MasterController.Controller.Player1InputMethod == "Controller"){
            Vertical_Axis = Input.GetAxis("Controller_Vertical_P1");
        }
        else
        {
            Vertical_Axis = Input.GetAxis("Keyboard_Vertical");
        }
        
        if (Vertical_Axis != 0)
        {
            if (!keyDown)
            {
                if (Vertical_Axis< 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (Vertical_Axis > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
    }
}
