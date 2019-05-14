using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class SelectionController : MonoBehaviour
{

    public GameObject PlayerSelect_Prefab;
    public GameObject SelectedPlayer_Prefab;
    public GameObject PlayerSelection_Grid;
    public GameObject Player1;
    public TextMeshProUGUI P1_Desc;
    public GameObject Player2;
    public TextMeshProUGUI P2_Desc;
    public Text p1_JoinText;
    public Text p2_JoinText;
    public GameObject FirstSelected;

    private bool addedCharacters = false;
    private bool player1isJoined = false;
    private bool player2isJoined = false;
    private bool addedFirst = false;
    private bool Selected_Keyboard = false;
    private bool Selected_Controller1 = false;
    private bool Selected_Controller2 = false;
    private int inputs = 0;

    private void Start() {
        if (!addedCharacters && MasterController.Controller != null)
        {
            if (MasterController.Controller.UnlockedFighters != null)
            {
                Debug.Log("Adding Characters");
                addedCharacters = true;
                AddCharacters();
            }
        }
        inputs = Input.GetJoystickNames().Count();
        if (inputs > 0)
        {
            p1_JoinText.text = "Press \"Left Click\" or \"A\" to join";
            p2_JoinText.text = "Press \"Left Click\" or \"A\" to join";
        }
        else{
            p1_JoinText.text = "Press \"Left Click\" to join";
            p2_JoinText.text = "Connect a controller to join!";

        }
        foreach(var x in Input.GetJoystickNames()){
            Debug.Log("JOYSTICK: " + x + "--");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        inputs = Input.GetJoystickNames().Count();
        if (player1isJoined)
        {
            p1_JoinText.text = "Choose your fighter!";
            p1_JoinText.color = Color.white;
        }
        if (player2isJoined)
        {
            p2_JoinText.text = "Choose your fighter!";
            p2_JoinText.color = Color.white;
        }
        //detect which device is selecting
        Selected_Keyboard = Input.GetAxisRaw("Keyboard_Fire1") > 0;
#if UNITY_STANDALONE_OSX
        Selected_Controller1 = Input.GetAxisRaw("Controller_Jump_P1") > 0;
        Selected_Controller2 = Input.GetAxisRaw("Controller_Jump_P2") > 0;
#else
        Selected_Controller1 = Input.GetAxisRaw("PC_Controller_Jump_P1") > 0;
        Selected_Controller2 = Input.GetAxisRaw("PC_Controller_Jump_P2") > 0;
#endif

        if (inputs > 0)
        {
            if (Selected_Keyboard)
            {
                Debug.Log("Joining player with keyboard");
                //join player with keyboard
                if (!player1isJoined)
                {
                    player1isJoined = true;
                    MasterController.Controller.Player1InputMethod = "Keyboard";
                }
                if (player1isJoined && !player2isJoined && MasterController.Controller.Player1InputMethod != "Keyboard")
                {
                    player2isJoined = true;
                    MasterController.Controller.Player2InputMethod = "Keyboard";
                }
            }
            if (Selected_Controller1)
            {
                Debug.Log("Joining Controller 1");
                if (player1isJoined && MasterController.Controller.Player1InputMethod == "Keyboard" && !player2isJoined)
                {
                    player2isJoined = true;
                    MasterController.Controller.Player2InputMethod = "Controller";
                }
                else if (!player1isJoined)
                {
                    player1isJoined = true;
                    MasterController.Controller.Player1InputMethod = "Controller";
                }
            }
            if ( Selected_Controller2 && !player2isJoined)
            {
                Debug.Log("Joining Controller 2");
                player2isJoined = true;
                MasterController.Controller.Player2InputMethod = "Controller";
            }
        }
        else if (inputs < 1 && !player1isJoined)
        {
            //If inputs < 1 then just keyboard
            player1isJoined = true;
            MasterController.Controller.Player1InputMethod = "Keyboard";
        }
    }

    private void AddCharacters()
    {
        if (MasterController.Controller.UnlockedFighters.Any())
        {
            foreach (var fighter in MasterController.Controller.UnlockedFighters)
            {
                InstantiateFighters(fighter);
            }
            InstantiateFighters(null, true);
        }
    }

    private void InstantiateFighters(string fighter, bool isLast = false)
    {
        GameObject character;
        if (!addedFirst)
        {
            character = FirstSelected;
            addedFirst = true;
        }
        else
            character = Instantiate(PlayerSelect_Prefab);

        string path;
        if (isLast)
        {
            path = Path.Combine("Portraits", "qm");
            character.GetComponent<Button>().onClick.AddListener(
                delegate { SelectCharacter("random"); }
            );
            character.name = "random";
        }
        else
        {
            path = Path.Combine("Portraits", fighter);
            character.GetComponent<Button>().onClick.AddListener(
                delegate { SelectCharacter(fighter); }
            );
            character.name = "Option-" + fighter;
        }

        var sp = Resources.Load<Sprite>(path);
        if (sp != null)
        {
            character.GetComponent<Image>().sprite = sp;
        }
        else
        {
            Debug.Log("Unable to load file at: " + path);
        }
        character.transform.SetParent(PlayerSelection_Grid.transform);
    }

    public void SelectCharacter(string name)
    {
        if(!player1isJoined && !player2isJoined){
            return;
        }

        int whichplayer = 0;
        GameObject playerObject;

        if (Selected_Keyboard)
        {
            if (inputs == 0)
            {
                whichplayer = 1;
            }
            else
            {
                whichplayer = MasterController.Controller.Player1InputMethod == "Keyboard" ? 1 :
                    MasterController.Controller.Player2InputMethod == "Keyboard" ? 2 : 0;
            }

        }
        else if (Selected_Controller1)
        {
            whichplayer = MasterController.Controller.Player1InputMethod == "Controller" ? 1 :
                MasterController.Controller.Player2InputMethod == "Controller" ? 2 : 0;
        }
        else if (Selected_Controller2)
        {
            whichplayer = 2;
        }

        if (whichplayer == 1)
        {
            playerObject = Player1;
            if(!player1isJoined)
                return;
        }
        else
        {
            playerObject = Player2;
            if(!player2isJoined)
                return;
        }

        Debug.Log("Selected " + name + "!");
        //check if already selected a character before
        if (playerObject.transform.childCount > 0)
        {
            foreach (Transform child in playerObject.transform)
            {
                Debug.Log("Removed Player: " + child.gameObject.name);
                Destroy(child.gameObject);
            }
        }

        if (name == "random")
        {
            name = GetRandomFighter();
        }
        var pref = Instantiate(SelectedPlayer_Prefab);
        var settings = pref.GetComponent<SelectedFighter>();

        settings.FighterName.text = name;

        //Add to player section
        pref.name = name;
        pref.transform.SetParent(playerObject.transform, false);

        string path = Path.Combine("Fighters", name);
        var x = Resources.Load<FighterBase>(path);
        var anim = x.UI_Animation;
        if (anim != null)
        {
            settings.FighterPortait.GetComponent<Animator>().runtimeAnimatorController = anim;
            if(whichplayer != 1)
                settings.FighterPortait.transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            Debug.Log("Unable to load animator");
        }
        if (whichplayer == 1)
        {
            P1_Desc.text = x.Description;
            //Set player in master controller
            MasterController.Controller.Fighter1 = name;
        }
        else
        {
            P2_Desc.text = x.Description;
            //Set player in master controller
            MasterController.Controller.Fighter2 = name;
        }
    }

    public void FinishSelection()
    {
        if(!player2isJoined){
            //Create AI Player
            MasterController.Controller.Player2InputMethod = "AI";
            if(string.IsNullOrEmpty( MasterController.Controller.Fighter2)){
                MasterController.Controller.Fighter2 = GetRandomFighter();
            }
        }
        var co = StartCoroutine(MasterController.Controller.ChangeScene(2));
    }

    public void ReturnToMain()
    {
        var co = StartCoroutine(MasterController.Controller.ChangeScene(0));
    }

    private string GetRandomFighter(){
        UnityEngine.Random.InitState((int)Time.time);
        int rand = UnityEngine.Random.Range(0,
        MasterController.Controller.UnlockedFighters.Count - 1);
        return MasterController.Controller.UnlockedFighters[rand];
    }

    private IEnumerator WaitASecond(){
        yield return new WaitForSeconds(2f);
    }
}
