using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnCollisionEnter(Collision Col)
    {
        if (Col.collider.tag == "monster")
        {
            //Replace 'Game Over' with your game over scene's name.
            SceneManager.LoadScene("GameOver");
            Destroy(this);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Monster_Eyes" && Character_Controller.hidden_player == false)
        {
            other.transform.parent.GetComponent<Monster>().Check_Sight();
        }
    }
}
