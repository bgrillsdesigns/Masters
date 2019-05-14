using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeLoadingScreen : MonoBehaviour {

    public Text TitleText;
    public GameObject TitleObject; 
    public GameObject LoadFinished; 
    public GameObject continueButton; 

	// Use this for initialization
	void Start () {
        StartCoroutine(FadeText());

    }
	
    IEnumerator FadeText()
    {
        float visibility = 1.0f;
        while (!continueButton.activeInHierarchy)
        {

            if (visibility == 0.0f)
            {
                while (TitleText.color.a < 1.0f)
                {
                    TitleText.color = new Color(TitleText.color.r, TitleText.color.g, TitleText.color.b, TitleText.color.a + (Time.deltaTime / visibility));
                    yield return null;
                }
            }

            if (visibility == 1.0f)
            {
                while (TitleText.color.a > 0.0f)
                {
                    TitleText.color = new Color(TitleText.color.r, TitleText.color.g, TitleText.color.b, TitleText.color.a - (Time.deltaTime / visibility));
                    yield return null;
                }
            }
        }

        TitleObject.SetActive(false);
        LoadFinished.SetActive(true);
    }
	// Update is called once per frame
	void Update () {

    }
}
