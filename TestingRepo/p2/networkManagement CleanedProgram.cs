using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
 
public class networkManagement : NetworkManager
{
 
    public int chosenCharacter = 0;

    public GameObject[] characters;

//commented out code was ommited here 

 
    //subclass for sending network messages
    public class NetworkMessage : MessageBase{
        public int chosenClass;
    }

	void Start(){	
		chosenCharacter = PlayerPrefs.GetInt("characterSelected", 0);

	}
 
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader){
		NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
		int selectedClass = message.chosenClass;
		Debug.Log("server add with message " + selectedClass);
 
		GameObject player;
		Transform startPos = GetStartPosition();
 
        if(startPos != null){
		    	player = Instantiate(characters[chosenCharacter], startPos.position,startPos.rotation)as GameObject;
        }
        else{
			    player = Instantiate(characters[chosenCharacter], Vector3.zero, Quaternion.identity) as GameObject;
        }
        
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
 
    }
 
    public override void OnClientConnect(NetworkConnection conn){
		NetworkMessage test = new NetworkMessage();
		test.chosenClass = chosenCharacter;
		
		ClientScene.AddPlayer(conn, 0, test);
    }
 
 
    public override void OnClientSceneChanged(NetworkConnection conn)
    {
//commented out code was ommited here 
    }
 

    public void btn1(){
		chosenCharacter = 0;
    }
 
    public void btn2(){
		chosenCharacter = 1;
    }

}