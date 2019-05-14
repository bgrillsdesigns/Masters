using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTextEvent : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered " + this.name);

        if (other.CompareTag("Player"))
        {
            FindObjectOfType<TextBoxManager>().GoNextLine();
            Destroy(gameObject);
        }

    }
}
