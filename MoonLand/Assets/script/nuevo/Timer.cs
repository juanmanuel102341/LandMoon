
using UnityEngine;

public class Timer : MonoBehaviour {

	public float respawn=1.0f; 
	private bool active=false;
	private float time;
	public delegate void Respawn();
	public static  event Respawn onRespawn;
	void Awake() {
		active=false;//booleano del timer 
	
		ColisionJugador.respawn+=OnTimeRespawn;//tomo evento deteccion del script colision jjugador cuando hay contacto se activa on time respawn calcula
													//un tiempo y manda genera un evento de respawn para el script colision jugador 

	}
	void Start(){
		enabled=false;//desactivo componente ya q no lo necesito	
	}
	void Update () {
	if(active){
	time+=Time.deltaTime;
		if(time>respawn){
				time=0;
				active=false;
				onRespawn();//activo respawn para q el player aparezca
				enabled=false;
				}
	   		}
	}
	void OnTimeRespawn(){
		enabled=true;//activo componente
		active=true;//activo timer
	}
}
