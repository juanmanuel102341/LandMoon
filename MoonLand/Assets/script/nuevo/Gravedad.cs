
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Gravedad : MonoBehaviour {
	public float fuerza;
	private float propx;
	private float propy;
	private float distancia;
	public Transform transformPlaneta;
	private Transform transformPersonaje;
	private Rigidbody2D rb;
	private float distanceInicial;
	private float distanciaAcumulada=0;
	private PlayerController_01 playerControl;

	private float n;
	private float distanceObj=0;
	private Vector2 posInicial;
	private float magnitud;
	private float constanteAcum=0;
	private float time;
	void Awake(){
		transformPersonaje=GetComponent<Transform>();
		rb=GetComponent<Rigidbody2D>();
		propx=PropX();
		propy=PropY();
		distanceInicial=Vector2.Distance(transformPersonaje.position,transformPlaneta.position);
		playerControl=GetComponent<PlayerController_01>();
		posInicial=transform.position;
		print("pos inicial "+posInicial);
	}

	float CalcDistance(){
		//distancia entre el personaje y planeta
		//print("distancia entre el planeta y jugador "+Vector2.Distance(transformPersonaje.position,transformPlaneta.position));
		return Vector2.Distance(transformPersonaje.position,transformPlaneta.position);
	}
	float Desplazamiento(){
		magnitud=fuerza*Time.deltaTime*constanteAcum;

		//print("magnitud "+magnitud);
		return magnitud;
	}

	float PropX(){
		//calculo la proporcion en x y divido la distancia, para saber cuanto me tengo q mover en x
		return (transformPlaneta.position.x-transformPersonaje.position.x)/CalcDistance();
	}
	float PropY(){
		//calculo la proporcion en x y divido la distancia, para saber cuanto me tengo q mover en y
		return (transformPlaneta.position.y-transformPersonaje.position.y)/CalcDistance();
	}


	void FixedUpdate(){
		
		propx=PropX();
		propy=PropY();
		//print("vertical speed "+Desplazamiento());
		//time+=Time.deltaTime;
		//if(time>0.5f){
		constanteAcum+=0.02f;
	//	}
		//magnitud=aceleracion-playerControl.SpeedPlayer;
		//print("distanciaAcumulada "+distanciaAcumulada);
		//print("magnitud"+magnitud);
		rb.transform.Translate(new Vector2(propx,propy)*Desplazamiento(),Space.World);//establezco el translate del vector segun las proporciones en x e y y establezco como referencia el mundo sino tengo problemas con la rotacion  
			
		}

	public float DistanciaRec{
		get {
			return magnitud; 
		}
		set {
			magnitud=value;
		}
	}
}

