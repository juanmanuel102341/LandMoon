using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour {
	public AudioSource audio_up;
	public AudioSource audio_Explosion;
	private bool active=false;
	public static bool soundOn=false;	
	// Use this for initialization
	void Awake() {
		PlayerController_02.Down+=OnDown;//player presina arriba
		PlayerController_02.Up+=OnUp;//deja de presionar arriba
		ColisionJugador.respawn+=OnColision;//player muere


		//if(audio_up!=null){
		//	print("clip cargado");
		//}
	}


	// Update is called once per frame
	void Update () {
		
	}
	void OnDown(){
		if(audio_up.isPlaying==false&&soundOn){
			
		print("arriba desde sonido");
		audio_up.Play();
		active=true;
		}
	}
	void OnUp(){
		print("dejo de presionar desde sonido");
		if(audio_up.isPlaying&&soundOn){
		audio_up.Stop();
			active=false;
		}

	}
	void OnColision(){
		print("colision ");
		if(!audio_Explosion.isPlaying&&soundOn){
			print("explosion");
			audio_Explosion.Play();
		}
	}


}
