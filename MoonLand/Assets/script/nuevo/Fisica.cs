using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisica : MonoBehaviour {
	private PlayerController_01 pc;
	private Gravedad g;
	// Use this for initialization
	void Start () {
		pc=GetComponent<PlayerController_01>();
		g=GetComponent<Gravedad>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		float n=g.DistanciaRec-pc.SpeedPlayer;
		print("diferencia velocidades "+n);
	}
}
