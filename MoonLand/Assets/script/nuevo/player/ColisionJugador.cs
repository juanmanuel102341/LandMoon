using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ColisionJugador : MonoBehaviour {

	private SpriteRenderer sprender;
	private Transform transformJugador;
	private Vector2 posInicial;
	private float rotInicial; 
	private Gravedad_02 gravedad;
	private PlayerController_02 playerController;
	public delegate void PlataformaContacto(string name);//informa al fill de la plataforma 
	public static event PlataformaContacto OnPlataformaContacto;
	public static event PlataformaContacto OnReset;
	public delegate void Deteccion();
	public static  event Deteccion respawn;
	public static event Deteccion aterrizaje;
	//public static event Deteccion colisionFuera;
	public delegate void UpdateGuiAterrizajes(int num);
	public static event UpdateGuiAterrizajes onUpdateGuiAterrizajes; 
	public delegate void UpdateGuiLife (int numVidas);
	public static event UpdateGuiLife OnUpdateLife_gui;
	//public List<GameObject>listaPlataformas=new List<GameObject>();
	private Rigidbody2D rb;
	public float limiteMuerte;//velocidad a q tiene q llegar para morir el player
	public float limiteRotacionEuler=15;//rotacion de margen q se le da al jugador al aterrizar
	private GameObject plataforma;
	private float diferencialEuler;
	private string currentPlataforma="";
	private int aterrizajes=0;
	private bool isTouching=false;// verifica q el player se mantenga en la plataforma 
	private Vector2 velocityImpact;
	private float rotationPLayer;
	private bool win=false;
	private bool gameOver=false;
	//private GameObject objPadreGame;
	public delegate void GameOver_01(bool _win);
	public static event GameOver_01 juegoTerminado;
	public int AterrizajesVictoria;
	void Awake () {
		sprender=GetComponent<SpriteRenderer>();
		transformJugador=GetComponent<Transform>();
		gravedad=GetComponent<Gravedad_02>();
		playerController=GetComponent<PlayerController_02>();
		posInicial=transformJugador.position;
		rotInicial=transformJugador.eulerAngles.z;
		rb=GetComponent<Rigidbody2D>();

		Timer.onRespawn+=OnRespawnPlayer;//evento q viene d timer cuando se cumple el respawn
		Timer.onAterrizajeFinish+=OnAterrizajePlayer;//evento q viene d timer cuando cumple el tiempo de permanecer en la zona de aterrizaje

		print("transform inicial "+transformJugador.position);
	}
	void Start(){
		OnUpdateLife_gui(playerController.CurrentVidas);//informo a gui cantidad d vidas
	}
	void  OnCollisionEnter2D(Collision2D c){
		plataforma=c.transform.gameObject;
	
		if(c.transform.tag=="plataforma_tag"&&!plataforma.GetComponent<Fill>().Deactive){
			//pregunto si tiene la tag y si no salio antes a traves d una propiedad
			print("plataforma");
			print("velocity impacto "+rb.velocity);
			currentPlataforma=c.transform.name;
			isTouching=true;
			//print("contacto velocity "+rb.velocity);
			OnContactoPlataforma();

		}
		if(plataforma.GetComponent<Fill>().Deactive){
			print("ya salio!!!");
		}

	}

	void OnTriggerEnter2D(Collider2D obj){
	//	print("contacto planeta");
		if(obj.tag=="planeta_tag"){
			print("contacto planeta");
			OnContactoObjeto();
		}else if(obj.tag=="sensor_tag"){
			print("sensor "+rb.velocity);
			velocityImpact=rb.velocity;
			velocityImpact.x=Mathf.Abs(velocityImpact.x);
			velocityImpact.y=Mathf.Abs(velocityImpact.y);

			rotationPLayer=transform.rotation.eulerAngles.z;
			rotationPLayer=Mathf.Abs(rotationPLayer);


		}
	}


	void  OnCollisionExit2D(Collision2D c){
		if(c.transform.tag=="plataforma_tag"){

			print("fuera plataforma");
			isTouching=false;
		
		}	
	}
	void OnContactoObjeto(){
		print("contacto jugador!!");
		gravedad.enabled=false;//desactivo gravedad 
		playerController.enabled=false;//desativo controles d jugador 
		sprender.enabled=false;//desactivo sprite del jugador
		playerController.CurrentVidas-=1;

		print("vidas jugador "+playerController.CurrentVidas);
		respawn();//activo evento al timer
	}
	void OnRespawnPlayer(){
		print("respawn player");
		if(playerController.CurrentVidas>0){
		print("respawn player");
		transformJugador.position=posInicial;//lo posiciono en su transform inicial
		transformJugador.eulerAngles=new Vector3(0.0f,0.0f,rotInicial);//reseteamos rotacion
		sprender.enabled=true;//activo sprite del jugador
		gravedad.enabled=true;//activo gravedad
		playerController.enabled=true;//activo controles d jugador 
			OnUpdateLife_gui(playerController.CurrentVidas);//informo a gui cantidad d vidas
		}else if(!gameOver) {
			//no tiene mas vidas
			print ("perdiste");

		
		//	componenteReset.enabled=true;
		//	componenteReset.InstanciaDerrota();
			gameOver=true;

			print("padre game desactivando");
			juegoTerminado(false);
			//objPadreGame.SetActive(false);
			//SceneManager.LoadSceneAsync("loose");

		}
	}
	void OnContactoPlataforma(){
		print("contaccto plataforma");
		print("jugador euler "+rotationPLayer);
		print("plataforma euler "+plataforma.transform.rotation.eulerAngles.z);
		diferencialEuler=plataforma.transform.rotation.eulerAngles.z-rotationPLayer;
		diferencialEuler=Mathf.Abs(diferencialEuler);
		print("diferencialEuler "+diferencialEuler);

		if(CondicionAterrizaje()){
			aterrizaje();//activo evento timer de aterrizaje
		}else{
			print("muerte player");
		}
			
	}
	bool CondicionAterrizaje(){
		
		//print("velocityImpact.x "+velocityImpact.x);
		//print("fuerza punto "+rb.GetRelativePointVelocity();
		
		//print("velocityImpact.y "+velocityImpact.y);
		//print ("limiteMuerte "+limiteMuerte);
		if(velocityImpact.x<=limiteMuerte&&velocityImpact.y<=limiteMuerte&&diferencialEuler<=limiteRotacionEuler){
			if(diferencialEuler<=5){
				print("aterrizaje potencial perfecto !!");
				return true;
			}
			return true;
			aterrizaje();//activo evento a timer, para q llleve la cuenta d tiempo d aterrizaje
			print("aterrizaje potencial normal");
		}else{
			OnContactoObjeto();
			print("muerte");
			return false;
			}
		return false;
	
	}
	void OnAterrizajePlayer(){
		//si el player siguio cumpliendo la condicion ahi si aterriza o no
		if (isTouching){
			OnPlataformaContacto(currentPlataforma);//activo evento para q se llene la barra
				if(diferencialEuler<=5){
				print("aterrizaje completo perfecto !!");
			}
			print("aterrizaje completo ");
			aterrizajes++;//incremento conteo de aterrizajes
			onUpdateGuiAterrizajes(aterrizajes);
		//	plataforma.GetComponent<BoxCollider2D>().enabled=false;
			isTouching=false;//reseteamos booleano
			if(aterrizajes>=AterrizajesVictoria){
				juegoTerminado(true);
			}
		}
		print("aterrizaje fallido ");
	}

	public int AterrizajesExitosos{
		get{
			return aterrizajes;
		}
		set{
			aterrizajes=value;
		}
	}
	public bool getGameOver{
		get{
			return gameOver;
		}
		set{
			gameOver=value;		
			}	
	}
	public Vector2 GetPosInicial{
		get{
			return posInicial;
		}
	}
	public float GetRotInicial{
		get{
			return rotInicial;
		}
	}
}
