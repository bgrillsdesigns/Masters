using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;
public class onHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {  
    
    public TextMeshProUGUI textMesh;
    public Button button;
    public Color mouseHoverColor = new Color(1, 1, 1);
    public Color normalColor = Color.white;

    //Sounds
    public AudioClip hoverSound;
    public AudioSource audioSource;


    public void OnPointerEnter(PointerEventData eventData){ 
        audioSource.PlayOneShot(hoverSound); 
        textMesh.color = mouseHoverColor; 
        }

    public void OnPointerExit(PointerEventData eventData) { textMesh.color = normalColor;}

    void Start(){
        Button thisButton = button.GetComponent<Button>();
        thisButton.onClick.AddListener(onClick);
    }

    public void onClick(){
        textMesh.color = normalColor;
    }
    
    
}
