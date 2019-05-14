using UnityEngine;
using System.Collections;


namespace TMPro.Examples
{
    
    public class Benchmark03 : MonoBehaviour
    {

        public int SpawnType = 0;
        public int NumberOfNPC = 12;

        public Font TheFont;

//commented out code was ommited here 

        void Awake()
        {

        }


        void Start()
        {
            for (int i = 0; i < NumberOfNPC; i++)
            {
                if (SpawnType == 0)
                {
                    // TextMesh Pro Implementation
//commented out code was ommited here 
                    GameObject go = new GameObject(); //"NPC " + i);
//commented out code was ommited here 

                    go.transform.position = new Vector3(0, 0, 0);
//commented out code was ommited here 
//commented out code was ommited here 
//commented out code was ommited here 

                    TextMeshPro textMeshPro = go.AddComponent<TextMeshPro>();
//commented out code was ommited here 
                    textMeshPro.alignment = TextAlignmentOptions.Center;
                    textMeshPro.fontSize = 96;

                    textMeshPro.text = "@";
                    textMeshPro.color = new Color32(255, 255, 0, 255);
//commented out code was ommited here 


                    // Spawn Floating Text
//commented out code was ommited here 
//commented out code was ommited here 
                }
                else
                {
                    // TextMesh Implementation
                    GameObject go = new GameObject(); //"NPC " + i);
//commented out code was ommited here 

                    go.transform.position = new Vector3(0, 0, 0);

                    TextMesh textMesh = go.AddComponent<TextMesh>();
                    textMesh.GetComponent<Renderer>().sharedMaterial = TheFont.material;
                    textMesh.font = TheFont;
                    textMesh.anchor = TextAnchor.MiddleCenter;
                    textMesh.fontSize = 96;

                    textMesh.color = new Color32(255, 255, 0, 255);
                    textMesh.text = "@";

                    // Spawn Floating Text
//commented out code was ommited here 
//commented out code was ommited here 
                }
            }
        }

    }
}
