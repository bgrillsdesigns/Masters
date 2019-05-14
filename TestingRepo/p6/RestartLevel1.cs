using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel1 : MonoBehaviour {

	public int count;
    public bool endReached = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if((count > 10000 || endReached) && Input.GetKeyDown("e") )
			ReloadGameAction();
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        // Set Hit object
        GameObject hit = collision.gameObject;
        // Test Tags for Item
        if (hit.tag == "Player") {
            endReached = true;
        }
    }
    void ReloadGameAction(){
		SceneManager.LoadScene(0);
	}
}
