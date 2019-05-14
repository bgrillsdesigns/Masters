using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight_Controller : MonoBehaviour
{
    public GameObject light;

    // Use this for initialization

    public void LightOn()
    {
        light.SetActive(true);
    }

    public void LightOff()
    {
        light.SetActive(false);
    }

}