using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Animator : MonoBehaviour {
    private static bool animate = true;
    private float timer = 0f;
    private float toRotate;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 temp;
    

    public void MovePosition()
    {
        for (float x = 0f; x < 5; x += Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, x / 60);
        }

    }

    public float GetTimer()
    {
        return timer;
    }

    public void SetTimer(float newTime)
    {
        timer = newTime;
    }

    public static bool GetAnimate()
    {
        return animate;
    }

    public void SetAnimate(bool newAnimate)
    {
        animate = newAnimate;
    }

    public void SetPositions(GameObject book, bool toAdd)
    {
        startPos = book.transform.localPosition;
        if (toAdd)
        {
            temp = startPos;
            endPos = new Vector3(startPos.x , startPos.y, startPos.z + 1f);
        }
        else
        {
            endPos = new Vector3(temp.x, temp.y, temp.z);
            startPos = temp;
        }
       
        MovePosition();
        startPos = endPos;


    }


}
