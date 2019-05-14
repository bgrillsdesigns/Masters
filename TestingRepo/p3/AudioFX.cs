using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioFX : MonoBehaviour {

    public AudioMixer audioMixer;

	public void SetSoundFX (float volume)
    {
        audioMixer.SetFloat("volumeMaster", volume);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("volumeMusic", volume);
        //check for battle scene? or MainMenu?
        if (AudioManager.instance.IsMute("Battle"))
        {
            AudioManager.instance.SetVolume("MainMenu", volume);
        }
        else
        {
            AudioManager.instance.SetVolume("Battle", volume);
        }
 
    }
}
