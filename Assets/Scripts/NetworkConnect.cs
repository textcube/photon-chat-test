using UnityEngine;
using System.Collections;

public class NetworkConnect : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	void OnJoinedLobby(){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom("test", true, true, 2);
	}
	
	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
