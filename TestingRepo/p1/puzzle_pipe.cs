using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class puzzle_pipe : MonoBehaviour {

    public AudioSource someSound;
    

    private void OnMouseDown()
    {
        if (!GameControl.youWin)
        {
            Time.timeScale = 0f;
            transform.Rotate(0f, 0f, 90f); // On click rotates 90 degrees
            if (Input.GetMouseButtonDown(0) == true)
            {
                GetComponent<AudioSource>().Play();
            }
        }
       
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0) == true)
        //{
        //    GetComponent<AudioSource>().Play();
        //}
    }
}
