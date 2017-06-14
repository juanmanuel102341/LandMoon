using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary2 : MonoBehaviour {
	public PlayerController controlPlayer;
	public CameraMovement cm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D c){
		print("deactive jugador");
		controlPlayer.enabled=true;
		cm.FrontSuperior=true;
	}

}
