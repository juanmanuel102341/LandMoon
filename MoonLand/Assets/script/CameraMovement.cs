using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	//camara se mueve si el personaje cruza el limite superior del escenario


	public PlayerController pc;
	private float heightBackround;
	public Transform transformPlayer;
	private bool activeFronteraSuperior=false;

	private GameObject gravity; 
	void Start () {
		//gravity=GameObject.FindGameObjectWithTag("gravedad");

		//Frontera.onLimite+=OnMove;
		heightBackround=GameObject.FindGameObjectWithTag("backImage").GetComponent<Transform>().position.y;
		print("heightBackround "+heightBackround);

		//print ("impulso propiedad "+pc.impulsoUp);
		//transform.position=new Vector2(transformPlayer.position);
		transform.position=new Vector3(transformPlayer.position.x,transformPlayer.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//vertical 
		print("i "+pc.impulso);
		if(this.transform.position.y>330.3){
		transform.position=new Vector3(transformPlayer.position.x,transformPlayer.position.y,transform.position.z);
		//transform.Translate(Vector2.up*pc.impulsoUp);
		}



		//if(activeFronteraSuperior){
			
		//	transform.Translate(Vector2.down*0.9f*Time.deltaTime);
		//}

	//	print ("impulso propiedad "+pc.impulsoUp);
	}

	void OnMove(){
	//	gravity.SetActive(true);
		//transform.SetParent(gravity.GetComponent<Transform>());
		//print ("impulso propiedad evento"+pc.impulsoUp);
		//activeFronteraSuperior=true;
				//print("camara movimiento");
	}
	public bool FrontSuperior{
		set{
			activeFronteraSuperior=value;
		}
	}



}
