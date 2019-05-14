The commented code began at line 55 and ended at line 103
The commented code is shown below:
                /*
 			
                 Vector4 animationTiling = WaterEditorUtility.GetMaterialVector("_AnimationTiling", sharedWaterMaterial);
                 Vector4 animationDirection = WaterEditorUtility.GetMaterialVector("_AnimationDirection", sharedWaterMaterial);
 			
                 float firstTilingU = animationTiling.x*100.0F;
                 float firstTilingV = animationTiling.y*100.0F;
                 float firstDirectionU = animationDirection.x;
                 float firstDirectionV = animationDirection.y;
 
                 float secondTilingU = animationTiling.z*100.0F;
                 float secondTilingV = animationTiling.w*100.0F;
                 float secondDirectionU = animationDirection.z;
                 float secondDirectionV = animationDirection.w;
 						
 			
                 EditorGUILayout.BeginHorizontal ();
                 firstTilingU = EditorGUILayout.FloatField("First Tiling U", firstTilingU);
                 firstTilingV = EditorGUILayout.FloatField("First Tiling V", firstTilingV);
                 EditorGUILayout.EndHorizontal ();
                 EditorGUILayout.BeginHorizontal ();
                 secondTilingU = EditorGUILayout.FloatField("Second Tiling U", secondTilingU);
                 secondTilingV = EditorGUILayout.FloatField("Second Tiling V", secondTilingV);
                 EditorGUILayout.EndHorizontal ();
 			
                 EditorGUILayout.BeginHorizontal ();
                 firstDirectionU = EditorGUILayout.FloatField("1st Animation U", firstDirectionU);
                 firstDirectionV = EditorGUILayout.FloatField("1st Animation V", firstDirectionV);
                 EditorGUILayout.EndHorizontal ();
                 EditorGUILayout.BeginHorizontal ();
                 secondDirectionU = EditorGUILayout.FloatField("2nd Animation U", secondDirectionU);
                 secondDirectionV = EditorGUILayout.FloatField("2nd Animation V", secondDirectionV);
                 EditorGUILayout.EndHorizontal ();
 		
                 animationDirection = new Vector4(firstDirectionU,firstDirectionV, secondDirectionU,secondDirectionV);
                 animationTiling = new Vector4(firstTilingU/100.0F,firstTilingV/100.0F, secondTilingU/100.0F,secondTilingV/100.0F);
 			
                 WaterEditorUtility.SetMaterialVector("_AnimationTiling", animationTiling, sharedWaterMaterial);
                 WaterEditorUtility.SetMaterialVector("_AnimationDirection", animationDirection, sharedWaterMaterial);
 			
                 EditorGUILayout.Separator ();
 			
                 GUILayout.Label ("Displacement Strength", EditorStyles.boldLabel);
 			
                 float heightDisplacement = WaterEditorUtility.GetMaterialFloat("_HeightDisplacement", sharedWaterMaterial);
 			
                 heightDisplacement = EditorGUILayout.Slider("Height", heightDisplacement, 0.0F, 5.0F);
                 WaterEditorUtility.SetMaterialFloat("_HeightDisplacement", heightDisplacement, sharedWaterMaterial);
                 */


