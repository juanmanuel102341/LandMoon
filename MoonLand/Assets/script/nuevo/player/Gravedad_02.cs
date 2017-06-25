
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Gravedad_02 : MonoBehaviour {
	private float fuerza;//fuerza de gravedad del planeta
	private float propx;
	private float propy;
	private float distancia;
	private Transform transformPlaneta;
	private Transform transformPersonaje;
	private Rigidbody2D rb;
	//private float distanceInicial;
	private PlayerController_02 playerControl;
	private Vector2 posInicial;
	private float constanteAcum=0;
	private float time;
	private float fuerzaVertical2=0;
	private bool active_key=false;
	public float frecuencia=0.4f;
	private float velocidad_01;
	//public static bool activeKey=false;
	void Awake(){
		transformPersonaje=GetComponent<Transform>();
		rb=GetComponent<Rigidbody2D>();
		//distanceInicial=Vector2.Distance(transformPersonaje.position,transformPlaneta.position);

		playerControl=GetComponent<PlayerController_02>();
		posInicial=transform.position;
//		print("pos inicial "+posInicial);
		active_key=false;
		Distancias.PlanetaCercanoDeteccion+=GetValuesPlanet;//evento que viene de distancias, establece planeta mas cercano
	}
	void Start(){
		
	}
	float PropX(){
		//calculo la proporcion en x y divido la distancia, para saber cuanto me tengo q mover en x
		return (transformPlaneta.position.x-transformPersonaje.position.x)/CalcDistance();
	}
	float PropY(){
		//calculo la proporcion en x y divido la distancia, para saber cuanto me tengo q mover en y
		return (transformPlaneta.position.y-transformPersonaje.position.y)/CalcDistance();
	}
	float CalcDistance(){
		//distancia entre el personaje y planeta
		//print("distancia entre el planeta y jugador "+Vector2.Distance(transformPersonaje.position,transformPlaneta.position));

		return Vector2.Distance(transformPersonaje.position,transformPlaneta.position);

	}
	void GetValuesPlanet(Transform _planetaCercano){
		transformPlaneta=_planetaCercano;
		print("posicion "+transformPlaneta.position);
		propx=PropX();//calculo la proporcion en x a partir del transform del planeta 
		propy=PropY();//idem en y
		fuerza=_planetaCercano.gameObject.GetComponent<PlanetaData>().fuerza;//tomo la fuerza
		print("fuerza "+fuerza);
		frecuencia=_planetaCercano.gameObject.GetComponent<PlanetaData>().frecuencia;//frecuencia de actualizacion de la fuerza
		print("frecuencia "+frecuencia);

		//print("desde gravedad planeta cercano "+_planetaCercano.name);

	}

	public void Desplazamiento(){


		if(constanteAcum<0){
		DesplazamientoGravedad();
		}else {
			constanteAcum=0;//la gravedad q se va acumulando n puede ser mas alta q 0
		}
	}
	void DesplazamientoGravedad(){
		propx=PropX();
		propy=PropY();
		rb.AddForce(new Vector2(propx,propy)*constanteAcum*-1);//multiplico x -1 para q vaya para abajo
	}


	void FixedUpdate(){
		Desplazamiento();
		//print("vertical speed "+Desplazamiento());
		time+=Time.deltaTime;
		//print(rb.velocity);
		if(time>frecuencia){
		constanteAcum-=fuerza;
		time=0.0f;
		//print("acum "+constanteAcum);
		}

		}


	public float MagnitudGravity2{
		get{
			return constanteAcum;
		}
		set{
			constanteAcum=value;
		}

	}

	public Vector2 Velocity{
		get{
			return rb.velocity;
		}

	}
	public bool ActiveKey_prop{
		get{
		return active_key;
		}
	set{
		active_key=value;
		}

	}		

}

