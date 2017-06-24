using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ColisionJugador : MonoBehaviour {

	private SpriteRenderer sprender;
	private Transform transformJugador;
	private Vector2 posInicial;
	private Gravedad gravedad;
	private PlayerController_02 playerController;
	public delegate void Deteccion();
	public static  event Deteccion respawn;
	public static event Deteccion aterrizaje;
	//public List<GameObject>listaPlataformas=new List<GameObject>();
	private Rigidbody2D rb;
	public float limiteMuerte;//velocidad a q tiene q llegar para morir el player
	public float limiteRotacionEuler=15;//rotacion de margen q se le da al jugador al aterrizar
	private GameObject plataforma;
	private float diferencialEuler;

	void Awake () {
		sprender=GetComponent<SpriteRenderer>();
		transformJugador=GetComponent<Transform>();
		gravedad=GetComponent<Gravedad>();
		playerController=GetComponent<PlayerController_02>();
		posInicial=transformJugador.position;
		rb=GetComponent<Rigidbody2D>();

		Timer.onRespawn+=OnRespawnPlayer;//evento q viene d timer cuando se cumple el respawn
		Timer.onAterrizajeFinish+=OnAterrizajePlayer;//evento q viene d timer cuando cumple el tiempo de permanecer en la zona de aterrizaje
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
			plataforma=c.gameObject;
			print("contacto velocity "+rb.velocity);
			OnContactoPlataforma();
			//Vector2 v=rb.GetRelativePointVelocity(this.GetComponent<Transform>().position);
			//print("fuerza contacto "+v);
	
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
		//print("contaccto plataforma");
		//print("jugador euler "+transform.rotation.eulerAngles.z);
		//print("plataforma euler "+plataforma.transform.rotation.eulerAngles.z);
		diferencialEuler=plataforma.transform.rotation.eulerAngles.z-transform.rotation.eulerAngles.z;
		diferencialEuler=Mathf.Abs(diferencialEuler);
		//print("diferencialEuler "+diferencialEuler);
		if(CondicionAterrizaje()){
			aterrizaje();//activo evento timer de aterrizaje
		}else{
			print("muerte player");
		}
			
	}
	bool CondicionAterrizaje(){
		if(rb.velocity.x>-limiteMuerte&&rb.velocity.y>-limiteMuerte&&diferencialEuler<=limiteRotacionEuler){
			if(diferencialEuler<=5){
			//	print("aterrizaje potencial perfecto !!");
				return true;
			}
			return true;
			aterrizaje();//activo evento a timer, para q llleve la cuenta d tiempo d aterrizaje
		//	print("aterrizaje potencial normal");
		}else{
			//print("muerte");
			return false;
			}
		return false;
	
	}
	void OnAterrizajePlayer(){
		//si el player siguio cumpliendo la condicion ahi si aterriza o no
		if (CondicionAterrizaje()){
			
				if(diferencialEuler<=5){
		//		print("aterrizaje completo perfecto !!");
			}
		//	print("aterrizaje completo ");
		}
		//print("aterrizaje fallido n te mantuviste!!");
	}
}