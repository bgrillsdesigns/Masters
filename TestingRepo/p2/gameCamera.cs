 using UnityEngine;
 
 public class gameCamera : MonoBehaviour
 {
     public Transform playerTransform;
     public int depth = 20;
 
     void LateUpdate()
     {
         if(playerTransform != null)
         {
             transform.position = playerTransform.position + new Vector3(0,15,depth);
         }
     }
 
     public void setTarget(Transform target)
     {
         playerTransform = target;
     }
 }