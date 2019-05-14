using UnityEngine;
using UnityEditor;

class WaterEditorUtility
{
	// helper functions to retrieve & set material values

	public static float GetMaterialFloat(System.String name, Material mat) {
		return mat.GetFloat(name);
	}
	public static void SetMaterialFloat(System.String name, float f, Material mat) {
		mat.SetFloat(name, f);
	}

	public static Color GetMaterialColor(System.String name, Material mat) {
		return mat.GetColor(name);
	}
	public static void SetMaterialColor(System.String name, Color color, Material mat) {
		mat.SetColor(name, color);
	}
	public static Vector4 GetMaterialVector(System.String name, Material mat) {
		return mat.GetVector(name);
	}
	public static void SetMaterialVector(System.String name, Vector4 vector, Material mat) {
		mat.SetVector(name, vector);
	}
	public static Texture GetMaterialTexture(System.String theName, Material mat) {
		return mat.GetTexture(theName);
	}
	public static void SetMaterialTexture(System.String theName, Texture parameter, Material mat) {
		mat.SetTexture(theName, parameter);
	}
	
	public static Material LocateValidWaterMaterial(Transform parent)
	{
		if(parent.GetComponent<Renderer>() && parent.GetComponent<Renderer>().sharedMaterial)
			return parent.GetComponent<Renderer>().sharedMaterial;
		foreach( Transform t in parent)
		{
			if(t.GetComponent<Renderer>() && t.GetComponent<Renderer>().sharedMaterial)
				return t.GetComponent<Renderer>().sharedMaterial;
		}
		return null;
	}
	
	public static void CurveGui (System.String name, SerializedObject serObj, Color color)
	{
		AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0.0f, 1.0f, 1.0f), new Keyframe(1, 1.0f, 1.0f, 1.0f));
		curve = EditorGUILayout.CurveField(new GUIContent (name), curve, color, new Rect (0.0f,0.0f,1.0f,1.0f));

		//if (GUI.changed) {
//commented out code was ommited here 
//commented out code was ommited here 
	   //}
	}
	/*
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 