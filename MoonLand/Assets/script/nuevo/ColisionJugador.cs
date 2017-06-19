using UnityEngine;

public class ColisionJugador : MonoBehaviour {

	private SpriteRenderer sprender;
	private Transform transformJugador;
	private Vector2 posInicial;
	private Gravedad gravedad;
	private PlayerController_01 playerController;
	public delegate void Deteccion();
	public static  event Deteccion respawn;
	public float limiteExplosionVelocidad=20;//variable q establece a q velocidad tiene q venir el objeto como limite para n morir

	void Awake () {
		sprender=GetComponent<SpriteRenderer>();
		transformJugador=GetComponent<Transform>();
		gravedad=GetComponent<Gravedad>();
		playerController=GetComponent<PlayerController_01>();
		posInicial=transformJugador.position;


		Timer.onRespawn+=OnRespawnPlayer;//evento q viene d timer cuando se cumple el respawn

	}
	void OnTriggerEnter2D(Collider2D c){
		print("colision");
		switch(c.tag){
		case"planeta_tag":
			OnContactoObjeto();
			break;
		case"plataforma_tag":
			OnContactoPlataforma();
			break;
		}

	}
	
	void OnContactoObjeto(){
		print("contacto jugador!!");
		gravedad.enabled=false;//desactivo gravedad 
		playerController.enabled=false;//desativo controles d jugador 
		sprender.enabled=false;//desactivo sprite del jugador
		playerController.Vidas-=1;
		print("vidas jugador "+playerController.Vidas);
		respawn();//activo evento al timer
	}
	void OnRespawnPlayer(){
		print("respawn player");
		transformJugador.position=posInicial;//lo posiciono en su posicion inicial
		sprender.enabled=true;//activo sprite del jugador
		gravedad.enabled=true;//activo gravedad
		playerController.enabled=true;//activo controles d jugador 
	}
	void OnContactoPlataforma(){

		print("contaccto plataforma");
		//if(playerController.velocity<)
	}
}
