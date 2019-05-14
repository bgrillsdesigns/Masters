using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour {

    public GameObject obj;

    public void Rotate()
    {
        obj.GetComponent<Animator>().Play("Take 001");
       

        
        
//commented out code was ommited here 
//commented out code was ommited here 
        
//commented out code was ommited here 
        //{
            
         // obj.transform.GetChild(1).transform.rotation = Quaternion.Lerp(start_rotation, end_rotation, x / 3);
       // }
    }
}
