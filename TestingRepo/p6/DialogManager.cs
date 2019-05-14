using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour {
    // Public Information
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI dialogText;
    public Animator animator;

    // Private Information
    private Queue<string> sentences;

	// Use this for initialization
	void Awake () {
        sentences = new Queue<string>();
	}

    public void StartDialog(Dialogue newDialog) {
        animator.SetBool("IsOpen", true);
        displayName.text = newDialog.displayName;
        //Display new sentences
        sentences.Clear();
        foreach(string sentence in newDialog.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(WaitTime());
    }
    IEnumerator TypeSentence(string sentence) {
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray()) {
            dialogText.text += letter;
            yield return null;
        }
    }
    IEnumerator WaitTime() {
        yield return new WaitForSecondsRealtime(5);
        DisplayNextSentence();
    }
    public void EndDialog() {
        animator.SetBool("IsOpen", false);
    }
}
