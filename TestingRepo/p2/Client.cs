using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Networking;
using UnityEngine;

public class Client : MonoBehaviour 
{
	public static Client Instances
	{
		private set; get;
	}

	private const int MAX_USER = 100;
	private const int PORT = 5190;
	private const int WEB_PORT = 5190;
	private const int BYTE_SIZE = 1024;
	//You can insert your own server by replacing the IP below
	private const string SERVER_IP = "192.168.0.3";

	private byte reliableChannel;
	private int connectionId;
	private int hostId;
	private byte error;

	//public Account self;
	private string token;
	private bool isStarted;
}