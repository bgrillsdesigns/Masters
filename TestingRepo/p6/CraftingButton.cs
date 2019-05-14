using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Interactable Item", menuName = "Crafting Recipe")]
public class CraftingButton : MonoBehaviour {

	public Button craftingButton1;
	public Button craftingButton2;
	public Button craftingButton3;
	public Button craftingButton4;
    private playerController player;

    private void Awake() {
        player = GameObject.Find("player").GetComponent<playerController>();
    }

    void Start(){
		craftingButton1.onClick.AddListener(craftRed);
		craftingButton2.onClick.AddListener(craftBlue);
		craftingButton3.onClick.AddListener(craftYellow);
		craftingButton4.onClick.AddListener(craftPurple);
	}

    public void craftRed() {
        player.Craft(5);
    }
    public void craftBlue() {
        player.Craft(6);
    }
    public void craftYellow() {
        player.Craft(7);
    }
    public void craftPurple() {
        player.Craft(8);
    }
}
