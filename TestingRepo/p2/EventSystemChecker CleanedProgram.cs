using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Prototype.NetworkLobby
{
    public class EventSystemChecker : MonoBehaviour
    {
//commented out code was ommited here 

        // Use this for initialization
        void Awake()
        {
            if (!FindObjectOfType<EventSystem>())
            {
//commented out code was ommited here 
                GameObject obj = new GameObject("EventSystem");
                obj.AddComponent<EventSystem>();
                obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
            }
        }
    }
}