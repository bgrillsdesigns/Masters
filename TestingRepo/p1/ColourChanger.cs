using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers

public class ColourChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ // Extends the pointer handlers

    // Test for enter and exit:
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.red; // Changes the colour of the text
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.yellow; // Changes the colour of the text
    }
}