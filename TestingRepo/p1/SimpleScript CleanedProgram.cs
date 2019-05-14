using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class SimpleScript : MonoBehaviour
    {

        private TextMeshPro m_textMeshPro;
//commented out code was ommited here 

        private const string label = "The <#0050FF>count is: </color>{0:2}";
        private float m_frame;


        void Start()
        {
            // Add new TextMesh Pro Component
            m_textMeshPro = gameObject.AddComponent<TextMeshPro>();

            m_textMeshPro.autoSizeTextContainer = true;

            // Load the Font Asset to be used.
//commented out code was ommited here 
//commented out code was ommited here 

            // Assign Material to TextMesh Pro Component
//commented out code was ommited here 
//commented out code was ommited here 
            
            // Set various font settings.
            m_textMeshPro.fontSize = 48;

            m_textMeshPro.alignment = TextAlignmentOptions.Center;
            
//commented out code was ommited here 
//commented out code was ommited here 

//commented out code was ommited here 
//commented out code was ommited here 

//commented out code was ommited here 
            m_textMeshPro.enableWordWrapping = false; 

//commented out code was ommited here 
        }


        void Update()
        {
            m_textMeshPro.SetText(label, m_frame % 1000);
            m_frame += 1 * Time.deltaTime;
        }

    }
}
