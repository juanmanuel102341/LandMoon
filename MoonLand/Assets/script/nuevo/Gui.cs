using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gui : MonoBehaviour {
	public Text t;
	public Gravedad gravedad;
	public PlayerController_01 playerController;
	float i=0.05f;
	// Use this for initialization
	void Start () {
		
		t.text=gravedad.FuerzaVertical_prop2.ToString();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		i+=0.02f;
		t.text=gravedad.FuerzaVertical_prop2.ToString();
	}
}
