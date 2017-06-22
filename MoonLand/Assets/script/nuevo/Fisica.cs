using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisica : MonoBehaviour {
	private PlayerController_01 pc;
	private Gravedad g;
	private Rigidbody2D rb;
	Vector2 vec;
	// Use this for initialization
	void Start () {
		pc=GetComponent<PlayerController_01>();
		g=GetComponent<Gravedad>();
		rb=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		//float n=g.DistanciaRec-pc.SpeedPlayer;
		//print("desp player "+pc.SpeedPlayer);
		//print("gravedad force "+g.SpeedGravity);
		Move();
	}
	void Move(){
		//vec=g.SpeedGravity+pc.SpeedPlayer;


	}
}