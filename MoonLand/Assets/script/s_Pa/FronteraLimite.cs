using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FronteraLimite : MonoBehaviour {

	public delegate void LimiteMaximo();
//	public static  event LimiteMaximo onLimiteMax;
	private float time;
	public float timeActive;
	private bool active=false;
	private BoxCollider2D box;
	public PlayerController pc;
	float aux;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(active){
		//	time+=Time.deltaTime;
		//}
		//if(time>timeActive){
		//	print("cumplio limite");
		//	box.enabled=true;
//		print("impulso "+pc.impulso);
		//time=0;
		if(active&&pc.impulso<-0.1){
			//active=false;
			print("limite");
			pc.moveActive=true;
			active=false;	
		}
		if(active&&Input.GetKeyUp(KeyCode.DownArrow)){
			aux=0;
		}
	}
	void OnTriggerEnter2D(Collider2D c){
		print("maximo");
		active=true;
		pc.moveActive=false;
		//box=c.GetComponent<BoxCollider2D>();
		//box.enabled=false;

	}
	void OnTriggerExit2D(Collider2D c){
		print("saliendo");
		//pc.enabled=true;


		//box=c.GetComponent<BoxCollider2D>();
		//box.enabled=false;

	}



}
