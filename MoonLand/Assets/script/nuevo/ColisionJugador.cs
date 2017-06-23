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
	private Rigidbody2D rb;
	void Awake () {
		sprender=GetComponent<SpriteRenderer>();
		transformJugador=GetComponent<Transform>();
		gravedad=GetComponent<Gravedad>();
		playerController=GetComponent<PlayerController_01>();
		posInicial=transformJugador.position;
		rb=GetComponent<Rigidbody2D>();

		Timer.onRespawn+=OnRespawnPlayer;//evento q viene d timer cuando se cumple el respawn

	}
	void OnTriggerEnter2D(Collider2D c){
		print("colision");
//		Rigidbody2D rb=c.GetComponent;
	
		switch(c.tag){
		case"planeta_tag":
			print("muerte");		
			//OnContactoObjeto();
			break;
		case"plataforma_tag":
			OnContactoPlataforma();
			Vector2 v=rb.GetRelativePointVelocity(this.GetComponent<Transform>().position);
			print("fuerza contacto "+v);
	
			//rb.GetPointVelocity
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
