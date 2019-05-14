using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour {

    public GameObject obj;

    public void Rotate()
    {
        obj.GetComponent<Animator>().Play("Take 001");
       

        
        
       //Quaternion start_rotation = obj.transform.transform.rotation;
       //Quaternion end_rotation = start_rotation * Quaternion.Euler(new Vector3(0f, +90f, 0f));
        
        //for (float x = 0f; x < 33; x += Time.deltaTime)
        //{
            
         // obj.transform.GetChild(1).transform.rotation = Quaternion.Lerp(start_rotation, end_rotation, x / 3);
       // }
    }
}
