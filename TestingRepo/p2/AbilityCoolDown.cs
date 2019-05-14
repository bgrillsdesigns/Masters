﻿// using UnityEngine;
// using System.Collections;
// using UnityEngine.UI;

// public class AbilityCoolDown : MonoBehaviour {

//     public string abilityButtonAxisName = "Secondary";
//     public Image darkMask;
//     public Text coolDownTextDisplay;

//     private Ability ability;
//     private GameObject weaponHolder;
//     private Image myButtonImage;
//     // private AudioSource abilitySource;
//     private float coolDownDuration;
//     private float nextReadyTime;
//     private float coolDownTimeLeft;


//     void Start () 
//     {
//         //Testing just WBC's rift
//         Initialize (ability, weaponHolder); 
//     }

//     public void Initialize(Ability selectedAbility, GameObject firePoint) //GameObject weaponHolder -- for the thing that fires the projectile
//     {
//         ability = selectedAbility;
//         myButtonImage = GetComponent<Image> ();
//         // abilitySource = GetComponent<AudioSource> ();
//         myButtonImage.sprite = ability.aSprite;
//         darkMask.sprite = ability.aSprite;
//         coolDownDuration = ability.aBaseCoolDown;
//         ability.Initialize (firePoint);


//         // abilities should not be ready upon beginning
//         nextReadyTime = coolDownDuration + Time.time;
//         coolDownTimeLeft = coolDownDuration;
//         darkMask.enabled = true;
//         coolDownTextDisplay.enabled = true;
//     }
    
//     // Update is called once per frame
//     void Update () 
//     {
//         bool coolDownComplete = (Time.time > nextReadyTime);
//         if (coolDownComplete) 
//         {
//             AbilityReady ();
//             if (Input.GetButtonDown (abilityButtonAxisName)) 
//             {
//                 ButtonTriggered ();
//             }
//         } else 
//         {
//             CoolDown();
//         }
//     }

//     private void AbilityReady()
//     {
//         coolDownTextDisplay.enabled = false;
//         darkMask.enabled = false;
//     }

//     private void CoolDown()
//     {
//         coolDownTimeLeft -= Time.deltaTime;
//         float roundedCd = Mathf.Round (coolDownTimeLeft);
//         coolDownTextDisplay.text = roundedCd.ToString ();
//         darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
//     }

//     private void ButtonTriggered()
//     {
//         nextReadyTime = coolDownDuration + Time.time;
//         coolDownTimeLeft = coolDownDuration;
//         darkMask.enabled = true;
//         coolDownTextDisplay.enabled = true;

//         // abilitySource.clip = ability.aSound;
//         // abilitySource.Play ();
//         //This is what will actually trigger the ability
//         ability.TriggerAbility ();
//     }
// }