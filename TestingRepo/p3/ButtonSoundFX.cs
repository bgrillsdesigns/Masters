using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundFX : MonoBehaviour {

    public AudioSource myFX;
    public AudioClip hover;
    public AudioClip click;

    public void hoverSound ()
    {
        myFX.PlayOneShot(hover);
    }

    public void clickSound()
    {
        myFX.PlayOneShot(click);
    }
}
