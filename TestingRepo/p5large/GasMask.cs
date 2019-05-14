using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasMask : MonoBehaviour {
    private Inventory inventory;
    private bool mask;
    public GameObject Gasmask_HUD;
    private Scene currentScene;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && inventory.slots[1] != null)
        {
            Gasmask_HUD.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("sceneToLoad", SceneManager.GetActiveScene().name);
            //currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("deathScreen");
        }
    }

    void OnTriggerExit(Collider other)
    {
        mask = false; Gasmask_HUD.SetActive(false);

    }

}
