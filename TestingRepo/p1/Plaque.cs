using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plaque : MonoBehaviour {

    public string msg;
    public GameObject obj;

    public void ChangeText()
    {
        obj.GetComponent<MessageTimer>().textBox.GetComponent<Text>().text = msg;
        obj.GetComponent<MessageTimer>().ResetTimer();

    }
}