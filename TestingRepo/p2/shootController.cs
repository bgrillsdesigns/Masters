using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class shootController : NetworkBehaviour {

	public characterData data;

	public bool isFiring;
    public bool usingSecondary;
    public bool usingUltimate;

	public GameObject bulletPrefab;
	private float spreadAngle = 15.0f;
	public int numShots;
	public float bulletSpeed;
	public float timeBetweenShots;
	private float shotCounter;

	private Quaternion qAngle;
	private Quaternion qDelta;

    public Ability ability;
    public Ability ultimate;

    private float secondaryDuration;
    private float secondaryNextTime;
    private float secondaryTimeLeft;

    private float ultimateDuration;
    private float ultimateNextTime;
    private float ultimateTimeLeft;

    public Image secFill;
    public Image secBG;
    public Image secIcon;
	public Text secTextDisplay;

    public Image ultFill;
    public Image ultBG;
    public Image ultIcon;
	public Text ultTextDisplay;

	public Transform firePoint;

    private int team;

    public void Awake(){
        team = GetComponent<PlayerStats>().team;
    }

	void Start(){
		//Importing data from SO
		//Finding that most data is already public to the prefabs, so not as much change is needed inside the characters
		numShots = data.numShots;
		timeBetweenShots = data.attackSpeed;
		bulletSpeed = data.shotSpeed;

		ability = data.abilities[1];
		ultimate = data.abilities[2];

		//Readying Abilities
        ability.Initialize(firePoint);

        //Secondary should be available upon spawn
        secondaryDuration = ability.aBaseCoolDown;
        secondaryNextTime = 0;
        secondaryTimeLeft = 0;

        ultimate.Initialize(firePoint);

        //Start Cooling off ultimate
        ultimateDuration = ultimate.aBaseCoolDown;
        ultimateNextTime = ultimateDuration + Time.time;
        ultimateTimeLeft = ultimateDuration;

        secIcon.sprite = ability.aSprite;
        ultIcon.sprite = ultimate.aSprite;

        // GameObject prefab = GameObject.Find("HUD_Player");
		// shootController cont = prefab.GetComponent<shootController>();
		// secFill = cont.secFill;
		// secTextDisplay = cont.secTextDisplay;
		// secBG = cont.secBG;
		// secIcon = cont.secIcon;
		// secIcon.sprite = ability.aSprite;
		// ultFill = cont.ultFill;
		// ultTextDisplay = cont.ultTextDisplay;
		// ultBG = cont.ultBG;
		// ultIcon = cont.ultIcon;
		// ultIcon.sprite = ultimate.aSprite;

	}


	void Update () {

        if(Input.GetMouseButtonUp(0)){
            isFiring = false;
        }
        if (Input.GetMouseButtonDown(0)){
            isFiring = true;
        }

        bool secondaryCooled = (Time.time > secondaryNextTime);
        if(secondaryCooled && Input.GetMouseButtonDown(1)){
        	AbilityFlash();
            usingSecondary = true;
        }
        else {
        	usingSecondary = false;
        	CoolDown();
        }

        bool ultimateCooled = (Time.time > ultimateNextTime);
        if (ultimateCooled && Input.GetKeyDown("q")){
        	UltimateFlash();
        	usingUltimate = true;
        }
        else {
        	usingUltimate = false;
        	UCoolDown();
        }

		if(this.isLocalPlayer && isFiring){
			CmdShoot();
		}

        if(this.isLocalPlayer && usingSecondary){
            CmdTriggerSecondary();
        }

        if(this.isLocalPlayer && usingUltimate){
            CmdTriggerUltimate();
        }

	}

	[Command]
	void CmdShoot(){
		shotCounter -= Time.deltaTime;
		if(shotCounter <= 0){
			qAngle = Quaternion.AngleAxis(-numShots / 2.0f * spreadAngle, transform.up) * transform.rotation;
			qDelta = Quaternion.AngleAxis(spreadAngle, transform.up);
			for (int i = 0; i < numShots; i++){
				GameObject newBullet =  Instantiate(bulletPrefab, firePoint.position, qAngle);
                newBullet.GetComponent<BulletController>().team = team;
				NetworkServer.Spawn(newBullet);
				qAngle = qDelta * qAngle;
			}
			shotCounter = timeBetweenShots;
		}
		else{

		}
	}

    [Command]
    void CmdTriggerSecondary(){
    	ability.TriggerAbility();
    }

    [Command]
    void CmdTriggerUltimate(){
    	ultimate.TriggerAbility();
    }

    //Flashes, when abilites are being used
    private void AbilityFlash()
    {
    	secTextDisplay.enabled = true;

    	secondaryNextTime = secondaryDuration + Time.time;
    	secondaryTimeLeft = secondaryDuration;

    	secBG.GetComponent<Image>().color = new Color32(238,30,38,84);
    }

    private void UltimateFlash()
    {
    	ultTextDisplay.enabled = true;

    	ultimateNextTime = ultimateDuration + Time.time;
    	ultimateTimeLeft = ultimateDuration;

    	ultBG.GetComponent<Image>().color = new Color32(238,30,38,84);
    }

    //Shows when abilites are ready
    private void AbilityReady()
    {
    	secTextDisplay.enabled = false;
    	secBG.GetComponent<Image>().color = new Color32(30,163,238,84);
    }

    private void UltimateReady()
    {
    	ultTextDisplay.enabled = false;
    	ultBG.GetComponent<Image>().color = new Color32(30,163,238,84);
    }


    //Cooling down abilities, seperated because available at different times
    private void CoolDown()
    {
        secondaryTimeLeft -= Time.deltaTime;
        if (secondaryTimeLeft < 0){
        	AbilityReady();
        }

        float roundedCd = Mathf.Round (secondaryTimeLeft);
        secTextDisplay.text = roundedCd.ToString ();
        secFill.fillAmount = 1 - (secondaryTimeLeft / secondaryDuration);
    }

    private void UCoolDown()
    {
        ultimateTimeLeft -= Time.deltaTime;
        if (ultimateTimeLeft < 0){
        	UltimateReady();
        }

        float roundedCd = Mathf.Round (ultimateTimeLeft);
        ultTextDisplay.text = roundedCd.ToString ();
        ultFill.fillAmount = 1 - (ultimateTimeLeft / ultimateDuration);
    }

    public void Reset()
    {
        isFiring = false;
        usingUltimate = false;
        usingSecondary = false;

        //Secondary should be available upon spawn
        secondaryDuration = ability.aBaseCoolDown;
        secondaryNextTime = 0;
        secondaryTimeLeft = 0;

         //Start Cooling off ultimate
        ultimateDuration = ultimate.aBaseCoolDown;
        ultimateNextTime = ultimateDuration + Time.time;
        ultimateTimeLeft = ultimateDuration;

        AbilityReady();
        UltimateFlash();
    }
}
