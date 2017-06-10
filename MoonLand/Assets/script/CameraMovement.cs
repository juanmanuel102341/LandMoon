using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	//camara se mueve si el personaje cruza el limite superior del escenario


	public PlayerController pc;
	private bool activeFronteraSuperior=false;

	private GameObject gravity; 
	void Start () {
		gravity=GameObject.FindGameObjectWithTag("gravedad");

		Frontera.onLimite+=OnMove;
	
		print ("impulso propiedad "+pc.impulsoUp);
	}
	
	// Update is called once per frame
	void Update () {

		if(activeFronteraSuperior){
			transform.Translate(Vector2.up*pc.impulsoUp);
		//	transform.Translate(Vector2.down*0.9f*Time.deltaTime);
		}

	//	print ("impulso propiedad "+pc.impulsoUp);
	}

	void OnMove(){
	//	gravity.SetActive(true);
		transform.SetParent(gravity.GetComponent<Transform>());
		//print ("impulso propiedad evento"+pc.impulsoUp);
		activeFronteraSuperior=true;
				//print("camara movimiento");
	}
	public bool FrontSuperior{
		set{
			activeFronteraSuperior=value;
		}
	}



}
