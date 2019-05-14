The commented code began at line 258 and ended at line 258
The commented code is shown below:
                   // Debug.Log("Link ID: \"" + linkInfo.GetLinkID() + "\"   Link Text: \"" + linkInfo.GetLinkText() + "\""); // Example of how to retrieve the Link ID and Link Text.


The commented code began at line 295 and ended at line 295
The commented code is shown below:
            //Debug.Log("OnPointerEnter()");


The commented code began at line 302 and ended at line 302
The commented code is shown below:
            //Debug.Log("OnPointerExit()");


The commented code began at line 309 and ended at line 309
The commented code is shown below:
            //Debug.Log("Click at POS: " + eventData.position + "  World POS: " + eventData.worldPosition);


The commented code began at line 314 and ended at line 333
The commented code is shown below:
            /*
             int charIndex = TMP_TextUtilities.FindIntersectingCharacter(m_TextMeshPro, Input.mousePosition, m_Camera, true);
             if (charIndex != -1 && charIndex != m_lastIndex)
             {
                 //Debug.Log("Character [" + m_TextMeshPro.textInfo.characterInfo[index].character + "] was selected at POS: " + eventData.position);
                 m_lastIndex = charIndex;
 
                 Color32 c = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                 int vertexIndex = m_TextMeshPro.textInfo.characterInfo[charIndex].vertexIndex;
 
                 UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;
 
                 uiVertices[vertexIndex + 0].color = c;
                 uiVertices[vertexIndex + 1].color = c;
                 uiVertices[vertexIndex + 2].color = c;
                 uiVertices[vertexIndex + 3].color = c;
 
                 m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);
             }
             */


The commented code began at line 339 and ended at line 393
The commented code is shown below:
            /*
             int wordIndex = TMP_TextUtilities.FindIntersectingWord(m_TextMeshPro, Input.mousePosition, m_Camera);
 
             // Clear previous word selection.
             if (m_TextPopup_RectTransform != null && m_selectedWord != -1 && (wordIndex == -1 || wordIndex != m_selectedWord))
             {
                 TMP_WordInfo wInfo = m_TextMeshPro.textInfo.wordInfo[m_selectedWord];
 
                 // Get a reference to the uiVertices array.
                 UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;
 
                 // Iterate through each of the characters of the word.
                 for (int i = 0; i < wInfo.characterCount; i++)
                 {
                     int vertexIndex = m_TextMeshPro.textInfo.characterInfo[wInfo.firstCharacterIndex + i].vertexIndex;
 
                     Color32 c = uiVertices[vertexIndex + 0].color.Tint(1.33333f);
 
                     uiVertices[vertexIndex + 0].color = c;
                     uiVertices[vertexIndex + 1].color = c;
                     uiVertices[vertexIndex + 2].color = c;
                     uiVertices[vertexIndex + 3].color = c;
                 }
 
                 m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);
 
                 m_selectedWord = -1;
             }
 
             // Handle word selection
             if (wordIndex != -1 && wordIndex != m_selectedWord)
             {
                 m_selectedWord = wordIndex;
 
                 TMP_WordInfo wInfo = m_TextMeshPro.textInfo.wordInfo[wordIndex];
 
                 // Get a reference to the uiVertices array.
                 UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;
 
                 // Iterate through each of the characters of the word.
                 for (int i = 0; i < wInfo.characterCount; i++)
                 {
                     int vertexIndex = m_TextMeshPro.textInfo.characterInfo[wInfo.firstCharacterIndex + i].vertexIndex;
 
                     Color32 c = uiVertices[vertexIndex + 0].color.Tint(0.75f);
 
                     uiVertices[vertexIndex + 0].color = c;
                     uiVertices[vertexIndex + 1].color = c;
                     uiVertices[vertexIndex + 2].color = c;
                     uiVertices[vertexIndex + 3].color = c;
                 }
 
                 m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);
             }
             */


The commented code began at line 398 and ended at line 446
The commented code is shown below:
            /*
             // Check if Mouse intersects any words and if so assign a random color to that word.
             int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);
             if (linkIndex != -1)
             {
                 TMP_LinkInfo linkInfo = m_TextMeshPro.textInfo.linkInfo[linkIndex];
                 int linkHashCode = linkInfo.hashCode;
 
                 //Debug.Log(TMP_TextUtilities.GetSimpleHashCode("id_02"));
 
                 switch (linkHashCode)
                 {
                     case 291445: // id_01
                         if (m_LinkObject01 == null)
                             m_LinkObject01 = Instantiate(Link_01_Prefab);
                         else
                         {
                             m_LinkObject01.gameObject.SetActive(true);
                         }
 
                         break;
                     case 291446: // id_02
                         break;
 
                 }
 
                 // Example of how to modify vertex attributes like colors
                 #region Vertex Attribute Modification Example
                 UIVertex[] uiVertices = m_TextMeshPro.textInfo.meshInfo.uiVertices;
 
                 Color32 c = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                 for (int i = 0; i < linkInfo.characterCount; i++)
                 {
                     TMP_CharacterInfo cInfo = m_TextMeshPro.textInfo.characterInfo[linkInfo.firstCharacterIndex + i];
 
                     if (!cInfo.isVisible) continue; // Skip invisible characters.
 
                     int vertexIndex = cInfo.vertexIndex;
 
                     uiVertices[vertexIndex + 0].color = c;
                     uiVertices[vertexIndex + 1].color = c;
                     uiVertices[vertexIndex + 2].color = c;
                     uiVertices[vertexIndex + 3].color = c;
                 }
 
                 m_TextMeshPro.canvasRenderer.SetVertices(uiVertices, uiVertices.Length);
                 #endregion
             }
             */


The commented code began at line 452 and ended at line 452
The commented code is shown below:
            //Debug.Log("OnPointerUp()");


