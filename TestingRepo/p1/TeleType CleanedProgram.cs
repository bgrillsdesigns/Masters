using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class TeleType : MonoBehaviour
    {


        //[Range(0, 100)]
//commented out code was ommited here 

        private string label01 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=1>";
        private string label02 = "Example <sprite=2> of using <sprite=7> <#ffa000>Graphics Inline</color> <sprite=5> with Text in <font=\"Bangers SDF\" material=\"Bangers SDF - Drop Shadow\">TextMesh<#40a0ff>Pro</color></font><sprite=0> and Unity<sprite=2>";


        private TMP_Text m_textMeshPro;


        void Awake()
        {
            // Get Reference to TextMeshPro Component
            m_textMeshPro = GetComponent<TMP_Text>();
            m_textMeshPro.text = label01;
            m_textMeshPro.enableWordWrapping = true;
            m_textMeshPro.alignment = TextAlignmentOptions.Top;



            //if (GetComponentInParent(typeof(Canvas)) as Canvas == null)
            //{
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 

            //    // Set RectTransform Size
//commented out code was ommited here 
//commented out code was ommited here 
            //}


        }


        IEnumerator Start()
        {

            // Force and update of the mesh to get valid information.
            m_textMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
            int counter = 0;
            int visibleCount = 0;

            while (true)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

                m_textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

                // Once the last character has been revealed, wait 1.0 second and start over.
                if (visibleCount >= totalVisibleCharacters)
                {
                    yield return new WaitForSeconds(1.0f);
                    m_textMeshPro.text = label02;
                    yield return new WaitForSeconds(1.0f);
                    m_textMeshPro.text = label01;
                    yield return new WaitForSeconds(1.0f);
                }

                counter += 1;

                yield return new WaitForSeconds(0.05f);
            }

//commented out code was ommited here 
        }

    }
}