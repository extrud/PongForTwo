using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class NetworkManagerPong : NetworkManager{
	public GameManagerNet Gm;
	public override void OnClientConnect (NetworkConnection conn)
	{
		base.OnClientConnect (conn);
		Gm.StartGame(10);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
