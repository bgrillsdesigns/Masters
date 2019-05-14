using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTimer : MonoBehaviour {
    private float timer = 3f;
    public GameObject textBox;
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            DisableMessage();
        }
	}

    public void ResetTimer()
    {
        timer = 3f;
    }

    public void DisableMessage()
    {
        textBox.transform.GetComponent<Text>().text = "";
    }

}
