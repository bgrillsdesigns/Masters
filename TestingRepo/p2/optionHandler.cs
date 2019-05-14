using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class optionHandler : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public TextMeshProUGUI masterTextMesh;
	public TextMeshProUGUI musicTextMesh;
	public TextMeshProUGUI SFXTextMesh;

	public Slider masterSlider;
	public Slider musicSlider;
	public Slider SFXSlider;

	public AudioMixer masterMixer;

	public Dropdown resolutionDropdown;

	public Toggle fullScreenCheckbox;
	Resolution[] resolutions;

	public Toggle customCursorCheckbox;

	void Start () {
		masterTextMesh.text = OptionControl.oControl.masterVolume.ToString() + "%";
		masterSlider.value = OptionControl.oControl.masterVolume / 100;
		masterMixer.SetFloat("masterVolume", Mathf.Log10(masterSlider.value) * 20);

		musicTextMesh.text = OptionControl.oControl.musicVolume.ToString() + "%";
		musicSlider.value = OptionControl.oControl.musicVolume / 100;
		masterMixer.SetFloat("musicVolume", Mathf.Log10(musicSlider.value) * 20);

		SFXTextMesh.text = OptionControl.oControl.SFXVolume.ToString() + "%";
		SFXSlider.value = OptionControl.oControl.SFXVolume / 100;
		masterMixer.SetFloat("SFXVolume", Mathf.Log10(SFXSlider.value) * 20);

		customCursorCheckbox.isOn = OptionControl.oControl.customCursor;
		fullScreenCheckbox.isOn = OptionControl.oControl.fullscreen;
		
		if(OptionControl.oControl.customCursor){
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		}
		else{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
		}

		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> resOptions = new List<string>();

		int currentResolutionIndex = 0;

		for(int i = 0; i < resolutions.Length; i++){
			string option = resolutions[i].width + " x " + resolutions[i].height; 
			resOptions.Add(option);

			if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(resOptions);
		resolutionDropdown.value = OptionControl.oControl.resolutionSelection;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetFullscreen(bool isFullscreen){
		Screen.fullScreen = isFullscreen;
		fullScreenCheckbox.isOn = isFullscreen;
		OptionControl.oControl.fullscreen = isFullscreen;
	}

	public void SetCustomCursor(bool usingCustomCursor){
		if(usingCustomCursor){
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		}
		else{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
		}
		customCursorCheckbox.isOn = usingCustomCursor;
		OptionControl.oControl.customCursor = usingCustomCursor;
	}

	public void SetResolution(int resolutionIndex){
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		OptionControl.oControl.resolutionSelection = resolutionIndex;
	}

// Master Volume Settings
	public void SetMasterSliderValue(float sliderValue){
		masterTextMesh.text = Mathf.FloorToInt(sliderValue * 100).ToString() + "%";
		OptionControl.oControl.masterVolume =  Mathf.Round(sliderValue * 100);

		masterMixer.SetFloat("masterVolume", Mathf.Log10(sliderValue) * 20);
	}
// End of Master Volume Settings

// Music Volume Settings
	public void SetMusicSliderValue(float sliderValue){
		musicTextMesh.text = Mathf.FloorToInt(sliderValue * 100).ToString() + "%";
		OptionControl.oControl.musicVolume =  Mathf.Round(sliderValue * 100);

		masterMixer.SetFloat("musicVolume", Mathf.Log10(sliderValue) * 20);
	}
// End of Music Volume Settings

//SFX Volume Settings
	public void SetSFXSliderValue(float sliderValue){
		SFXTextMesh.text = Mathf.FloorToInt(sliderValue * 100).ToString() + "%";
		OptionControl.oControl.SFXVolume =  Mathf.Round(sliderValue * 100);

		masterMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
	}
// End of SFX Volume Settings

}
