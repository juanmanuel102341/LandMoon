
using UnityEngine;

public class Timer : MonoBehaviour {

	public float respawn=1.0f; 
	public float timeAterrizaje=1.5f;
	private bool active=false;
	private float time;
	public delegate void Timer_del();
	public static  event Timer_del onRespawn;
	public static event Timer_del onAterrizajeFinish;
	private event Timer_del current;
	private float currentTime;
	void Awake() {
		active=false;//booleano del timer 
	
		ColisionJugador.respawn+=OnTimeRespawn;//tomo evento deteccion del script colision jjugador cuando hay contacto se activa on time respawn calcula
													//un tiempo y manda genera un evento de respawn para el script colision jugador 
		ColisionJugador.aterrizaje+=OnTimeAterrizaje;//viene tb d colision , cuando el player aterriza
	}
	void Start(){
		enabled=false;//desactivo componente ya q no lo necesito	
	}
	void Update () {
			if(active){
			time+=Time.deltaTime;
			//print("tiempo "+time);
			if(time>currentTime){
			//	print("tiempo cumplido");
			current();		
			active=false;
			time=0;
			enabled=false;

			
			}
		}
	}


	void OnTimeRespawn(){
		enabled=true;//activo componente
		active=true;//activo timer

	}
	void Respawn(){
		if(time>respawn){
			time=0;
			active=false;
			current=onRespawn;//activo respawn para q el player aparezca
			enabled=false;
			currentTime=respawn;//le paso al timer el tiempo requerido
		}
	}
	void OnTimeAterrizaje(){
		print("aterrizaje conteo");
		enabled=true;//activo componente
		active=true;//activo timer
		current=onAterrizajeFinish;
		currentTime=timeAterrizaje;//le paso a timer tiempo rquerido
	} 
}
