The commented code began at line 1 and ended at line 1
The commented code is shown below:
﻿// using UnityEngine;


The commented code began at line 2 and ended at line 2
The commented code is shown below:
// using System.Collections;


The commented code began at line 3 and ended at line 3
The commented code is shown below:
// using UnityEngine.UI;


The commented code began at line 7 and ended at line 7
The commented code is shown below:
//     public string abilityButtonAxisName = "Secondary";


The commented code began at line 8 and ended at line 8
The commented code is shown below:
//     public Image darkMask;


The commented code began at line 9 and ended at line 9
The commented code is shown below:
//     public Text coolDownTextDisplay;


The commented code began at line 11 and ended at line 11
The commented code is shown below:
//     private Ability ability;


The commented code began at line 12 and ended at line 12
The commented code is shown below:
//     private GameObject weaponHolder;


The commented code began at line 13 and ended at line 13
The commented code is shown below:
//     private Image myButtonImage;


The commented code began at line 14 and ended at line 14
The commented code is shown below:
//     // private AudioSource abilitySource;


The commented code began at line 14 and ended at line 14
The commented code is shown below:
//     // private AudioSource abilitySource;


The commented code began at line 15 and ended at line 15
The commented code is shown below:
//     private float coolDownDuration;


The commented code began at line 16 and ended at line 16
The commented code is shown below:
//     private float nextReadyTime;


The commented code began at line 17 and ended at line 17
The commented code is shown below:
//     private float coolDownTimeLeft;


The commented code began at line 23 and ended at line 23
The commented code is shown below:
//         Initialize (ability, weaponHolder); 


The commented code began at line 28 and ended at line 28
The commented code is shown below:
//         ability = selectedAbility;


The commented code began at line 29 and ended at line 29
The commented code is shown below:
//         myButtonImage = GetComponent<Image> ();


The commented code began at line 30 and ended at line 30
The commented code is shown below:
//         // abilitySource = GetComponent<AudioSource> ();


The commented code began at line 30 and ended at line 30
The commented code is shown below:
//         // abilitySource = GetComponent<AudioSource> ();


The commented code began at line 31 and ended at line 31
The commented code is shown below:
//         myButtonImage.sprite = ability.aSprite;


The commented code began at line 32 and ended at line 32
The commented code is shown below:
//         darkMask.sprite = ability.aSprite;


The commented code began at line 33 and ended at line 33
The commented code is shown below:
//         coolDownDuration = ability.aBaseCoolDown;


The commented code began at line 34 and ended at line 34
The commented code is shown below:
//         ability.Initialize (firePoint);


The commented code began at line 38 and ended at line 38
The commented code is shown below:
//         nextReadyTime = coolDownDuration + Time.time;


The commented code began at line 39 and ended at line 39
The commented code is shown below:
//         coolDownTimeLeft = coolDownDuration;


The commented code began at line 40 and ended at line 40
The commented code is shown below:
//         darkMask.enabled = true;


The commented code began at line 41 and ended at line 41
The commented code is shown below:
//         coolDownTextDisplay.enabled = true;


The commented code began at line 47 and ended at line 47
The commented code is shown below:
//         bool coolDownComplete = (Time.time > nextReadyTime);


The commented code began at line 50 and ended at line 50
The commented code is shown below:
//             AbilityReady ();


The commented code began at line 53 and ended at line 53
The commented code is shown below:
//                 ButtonTriggered ();


The commented code began at line 57 and ended at line 57
The commented code is shown below:
//             CoolDown();


The commented code began at line 63 and ended at line 63
The commented code is shown below:
//         coolDownTextDisplay.enabled = false;


The commented code began at line 64 and ended at line 64
The commented code is shown below:
//         darkMask.enabled = false;


The commented code began at line 69 and ended at line 69
The commented code is shown below:
//         coolDownTimeLeft -= Time.deltaTime;


The commented code began at line 70 and ended at line 70
The commented code is shown below:
//         float roundedCd = Mathf.Round (coolDownTimeLeft);


The commented code began at line 71 and ended at line 71
The commented code is shown below:
//         coolDownTextDisplay.text = roundedCd.ToString ();


The commented code began at line 72 and ended at line 72
The commented code is shown below:
//         darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);


The commented code began at line 77 and ended at line 77
The commented code is shown below:
//         nextReadyTime = coolDownDuration + Time.time;


The commented code began at line 78 and ended at line 78
The commented code is shown below:
//         coolDownTimeLeft = coolDownDuration;


The commented code began at line 79 and ended at line 79
The commented code is shown below:
//         darkMask.enabled = true;


The commented code began at line 80 and ended at line 80
The commented code is shown below:
//         coolDownTextDisplay.enabled = true;


The commented code began at line 82 and ended at line 82
The commented code is shown below:
//         // abilitySource.clip = ability.aSound;


The commented code began at line 82 and ended at line 82
The commented code is shown below:
//         // abilitySource.clip = ability.aSound;


The commented code began at line 83 and ended at line 83
The commented code is shown below:
//         // abilitySource.Play ();


The commented code began at line 83 and ended at line 83
The commented code is shown below:
//         // abilitySource.Play ();


The commented code began at line 85 and ended at line 85
The commented code is shown below:
//         ability.TriggerAbility ();


