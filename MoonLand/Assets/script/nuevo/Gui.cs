using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gui : MonoBehaviour {
	public Text t;
	public Gravedad_02 gravedad;
	public PlayerController_02 playerController;

	// Use this for initialization
	void Start () {
		
		t.text=gravedad.Velocity.ToString();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		t.text=gravedad.Velocity.ToString();
	}
}
