using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{

    public Slider masterVolume;
    public Slider effectVolume;
    public Slider musicVolume;
    public Button saveButton;
    public AudioMixer playerAudio;
    public Dropdown windowDropdown;
    public Dropdown resolutionDropdown;

    public static SettingsController settings;

    Resolution[] resolutions;

    private void Start()
    {
        loadWindowMode();
        loadResolutions();

        //Add saving to save button
        saveButton.onClick.AddListener(Save);

        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("master", masterVolume.value);
        PlayerPrefs.SetFloat("music", musicVolume.value);
        PlayerPrefs.SetFloat("effect", effectVolume.value);

        UpdateVolume(PlayerPrefs.GetFloat("master"), PlayerPrefs.GetFloat("effect"), PlayerPrefs.GetFloat("music"));

        Debug.Log("Settings Saved!");
    }
    public void Load()
    {
        UpdateVolume(PlayerPrefs.GetFloat("master"), PlayerPrefs.GetFloat("effect"), PlayerPrefs.GetFloat("music"));


        Debug.Log("Settings Loaded!");
    }

    public void loadResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void loadWindowMode()
    {
        windowDropdown.ClearOptions();

        List<string> options = new List<string>();

        options.Add("Full Screen");
        options.Add("Windowed");

        windowDropdown.AddOptions(options);

        if (Screen.fullScreen)
            resolutionDropdown.value = 0;
        else
            resolutionDropdown.value = 1;

        windowDropdown.RefreshShownValue();
    }

    private void UpdateVolume(float mast, float ef, float mus)
    {
        playerAudio.SetFloat("Master", Mathf.Log10(mast) * 20);
        playerAudio.SetFloat("Effects", Mathf.Log10(ef) * 20);
        playerAudio.SetFloat("Music", Mathf.Log10(mus) * 20);
    }
    private void UpdateWindow(int choice)
    {
        //Fullscreen
        if (choice == 0)
        {
            Screen.fullScreen = true;
        }
        // Windowed
        else if (choice == 1)
        {
            Screen.fullScreen = false;
        }
        else
            Debug.Log("Window Error");
    }
    public void UpdateResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    [Serializable]
    public class PlayerSettings
    {
        public float masterVolume;
        public float effectVolume;
        public float musicVolume;

        //Constructor
        public PlayerSettings(float master, float effect, float music)
        {
            masterVolume = master;
            effectVolume = effect;
            musicVolume = music;
        }
    }
}
