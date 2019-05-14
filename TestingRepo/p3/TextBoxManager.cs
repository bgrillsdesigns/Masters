using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public GameObject textTrigger;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public Fighter player;

    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<Fighter>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        theText.text = textLines[currentLine];
    }

    public void GoNextLine()
    {
        currentLine += 1;
    }
}
