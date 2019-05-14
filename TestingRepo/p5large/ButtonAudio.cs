using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonAudio : EventTrigger
{
    private AudioSource audioSource;
    private AudioClip ClickSound;
    private AudioClip HoverSound;

    public void Awake()
    {
        audioSource = GameObject.Find("Effects Player").GetComponent<AudioSource>();
        ClickSound = Resources.Load<AudioClip>("Sounds/ButtonClick");
        HoverSound = Resources.Load<AudioClip>("Sounds/ButtonHover");
    }

    public override void OnMove(AxisEventData data)
    {
        audioSource.volume = 0.2F;

        audioSource.clip = HoverSound;
        audioSource.Play();
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        audioSource.volume = 0.2F;

        audioSource.clip = HoverSound;
        audioSource.Play();
    }

    public override void OnPointerDown(PointerEventData data)
    {
        audioSource.volume = 0.5F;

        audioSource.clip = ClickSound;
        audioSource.Play();
    }
}
