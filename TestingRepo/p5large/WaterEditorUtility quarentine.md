The commented code began at line 52 and ended at line 52
The commented code is shown below:
		//	AnimationCurveChanged(((WaterBase)serObj.targetObject).sharedMaterial, curve);


The commented code began at line 53 and ended at line 53
The commented code is shown below:
			//((WaterBase)serObj.targetObject).gameObject.SendMessage ("AnimationCurveChanged", SendMessageOptions.DontRequireReceiver);


The commented code began at line 57 and ended at line 75
The commented code is shown below:
	/*
 	public static void AnimationCurveChanged(Material sharedMaterial, AnimationCurve fresnelCurve)
 	{
 		Debug.Log("AnimationCurveChanged");
 		Texture2D fresnel = (Texture2D)sharedMaterial.GetTexture("_Fresnel");
 		if(!fresnel)
 			fresnel = new Texture2D(256,1);
 			
 		for (int i = 0; i < 256; i++)
 		{
 			float val = Mathf.Clamp01(fresnelCurve.Evaluate((float)i)/255.0f);
 			Debug.Log(""+(((float)i)/255.0f) +": "+val);
 			fresnel.SetPixel(i, 0, new Color(val,val,val,val));
 		}
 		fresnel.Apply();
 		
 		sharedMaterial.SetTexture("_Fresnel", fresnel);
 		
 	}	*/


