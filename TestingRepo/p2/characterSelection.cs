using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class characterSelection : MonoBehaviour {
	private GameObject[] characterList;
	private int index;

	public TextMeshProUGUI characterNameTMP;

	public TextMeshProUGUI characterAbilityOneDesc;
	public TextMeshProUGUI characterAbilityTwoDesc;
	public TextMeshProUGUI characterAbilityThreeDesc;

	public Image abilityOneSprite;
	public Image abilityTwoSprite;
	public Image abilityThreeSprite;

	private characterData charData;

	void Awake(){

	}
	void Start () {
		characterList = new GameObject[transform.childCount];

		for(int i = 0; i < transform.childCount; i++){
			characterList[i] = transform.GetChild(i).gameObject;
		}

		foreach(GameObject go in characterList){
			go.SetActive(false);
		}

		if(characterList[0]){
			characterList[0].SetActive(true);
			charData = characterList[0].GetComponent<selectedCharacter>().data;
			changeInformation(0);
			
			Debug.Log(charData.characterName);
		}
	}

	public void togglePrev(){
		characterList[index].SetActive(false);

		index--;
		if(index < 0){
			index = characterList.Length - 1;
		}

		characterList[index].SetActive(true);
		changeInformation(index);
	}

	public void toggleNext(){
		characterList[index].SetActive(false);

		index++;
		if(index == characterList.Length){
			index = 0;
		}

		characterList[index].SetActive(true);
		changeInformation(index);
	}

	public void confirmButton(){
		PlayerPrefs.SetInt("characterSelected", index);
		SceneManager.LoadScene("BioKnights II");
	}

	public void changeInformation(int id){
		charData = characterList[id].GetComponent<selectedCharacter>().data;
		characterNameTMP.text = charData.characterName;
		characterAbilityOneDesc.text = charData.abilities[0].description;
		characterAbilityTwoDesc.text = charData.abilities[1].description;
		characterAbilityThreeDesc.text = charData.abilities[2].description;
		abilityOneSprite.sprite = charData.abilities[0].aSprite;
		abilityTwoSprite.sprite = charData.abilities[1].aSprite;
		abilityThreeSprite.sprite = charData.abilities[2].aSprite;
	}

}
