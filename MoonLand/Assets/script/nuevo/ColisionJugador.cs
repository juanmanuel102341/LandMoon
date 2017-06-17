using UnityEngine;

public class ColisionJugador : MonoBehaviour {

	private SpriteRenderer sprender;
	private Transform transformJugador;
	private Vector2 posInicial;
	private Gravedad gravedad;
	private PlayerController_01 playerController;
	void Awake () {
		sprender=GetComponent<SpriteRenderer>();
		transformJugador=GetComponent<Transform>();
		gravedad=GetComponent<Gravedad>();
		playerController=GetComponent<PlayerController_01>();
		posInicial=transformJugador.position;

		ColisionPlaneta.onDeteccion+=OnContacto;//evento q se activa en el contacto con planeta
		Timer.onRespawn+=OnRespawnPlayer;//evento q viene d timer cuando se cumple el respawn
		}
	
	void OnContacto(){
		print("contacto jugador!!");
		gravedad.enabled=false;//desactivo gravedad 
		playerController.enabled=false;//desativo controles d jugador 
		sprender.enabled=false;//desactivo sprite del jugador
		playerController.Vidas-=1;
		print("vidas jugador "+playerController.Vidas);
	}
	void OnRespawnPlayer(){
		print("respawn player");
		transformJugador.position=posInicial;//lo posiciono en su posicion inicial
		sprender.enabled=true;//activo sprite del jugador
		gravedad.enabled=true;//activo gravedad
		playerController.enabled=true;//activo controles d jugador 
	}
}
