using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class OptionControl : MonoBehaviour {

	public static OptionControl oControl;

	public float masterVolume;
	public float musicVolume;
	public float SFXVolume;
	public int resolutionSelection;
	public bool customCursor;
	public bool fullscreen;
	
	void Awake(){
		Load();
		if(oControl == null){
			DontDestroyOnLoad(gameObject);
			oControl = this;
		}
		else if(oControl != this){
			Destroy(gameObject);
		}
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/options.dat");

		OptionData data = new OptionData();
		data.masterVolume = masterVolume;
		data.musicVolume = musicVolume;
		data.SFXVolume = SFXVolume;
		data.resolutionSelection = resolutionSelection;
		data.customCursor = customCursor;
		data.fullscreen = fullscreen;

		bf.Serialize(file, data);
		file.Close();
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/options.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/options.dat", FileMode.Open);
			OptionData data = (OptionData)bf.Deserialize(file);
			file.Close();

			masterVolume = data.masterVolume;
			musicVolume = data.musicVolume;
			SFXVolume = data.SFXVolume;
			resolutionSelection = data.resolutionSelection;
			customCursor = data.customCursor;
			fullscreen = data.fullscreen;
		}
	}
}

[Serializable]
class OptionData{
	public float masterVolume;
	public float musicVolume;
	public float SFXVolume;
	public int resolutionSelection;
	public bool customCursor;
	public bool fullscreen;
}
