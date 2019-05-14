﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveLighting : MonoBehaviour
{
    public bool enter = true;
    public bool exit = true;
    public int counter = 0; 

    private void OnTriggerEnter(Collider other)
    {
//commented out code was ommited here 
        if (enter && other.gameObject.tag == "Fire")
        {
//commented out code was ommited here 
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                other.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            
        }

        else if (enter && other.gameObject.tag == "ShadowPeople")
        {
//commented out code was ommited here 
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            counter++; 
        }

       
        else if (enter && other.gameObject.tag == "ShadowPeopleContact")
        {
//commented out code was ommited here 
            other.gameObject.SetActive(false);
            counter++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit && other.gameObject.tag == "Fire")
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            if (gameObject.transform.childCount > 1)
            {
                other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        if (other.gameObject.tag == "ShadowPeople" && counter > 1)
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
