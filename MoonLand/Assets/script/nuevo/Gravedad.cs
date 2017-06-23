
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Gravedad : MonoBehaviour {
	private float propx;
	private float propy;
	private float distancia;
	public Transform transformPlaneta;
	private Transform transformPersonaje;
	private Rigidbody2D rb;
	private float distanceInicial;
	private PlayerController_01 playerControl;
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
		propx=PropX();
		propy=PropY();
		distanceInicial=Vector2.Distance(transformPersonaje.position,transformPlaneta.position);
		playerControl=GetComponent<PlayerController_01>();
		posInicial=transform.position;
//		print("pos inicial "+posInicial);
		active_key=false;
	}

	float CalcDistance(){
		//distancia entre el personaje y planeta
		//print("distancia entre el planeta y jugador "+Vector2.Distance(transformPersonaje.position,transformPlaneta.position));
		return Vector2.Distance(transformPersonaje.position,transformPlaneta.position);
	}
	public void Desplazamiento(){


		fuerzaVertical2=constanteAcum+playerControl.MagnitudVelocidad2;
		velocidad_01=(fuerzaVertical2/frecuencia)*60;
	//	print(fuerzaVertical2);

		print("velocidad_01 "+velocidad_01);

		if(fuerzaVertical2<0.0f){
	//		print("gana gravedad comun");
			DesplazamientoGravedad(-1);
		}
		if(fuerzaVertical2>0.0f&&active_key==false){
	//		print("player suspendido");
			DesplazamientoGravedad(1);
		}
	}
	void DesplazamientoGravedad(int direccion){
		propx=PropX();
		propy=PropY();
		rb.transform.Translate(new Vector2(propx,propy)*fuerzaVertical2*direccion*Time.deltaTime,Space.World);
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
		Desplazamiento();
		//print("vertical speed "+Desplazamiento());
		time+=Time.deltaTime;
		if(time>frecuencia&&active_key==false){
		constanteAcum-=0.2f;
		time=0.0f;
		//print("acum "+constanteAcum);
		}

		}


	public float MagnitudGravity2{
		get{
			return constanteAcum;
		}


	}

	public float FuerzaVertical_prop2{
		get{
			return fuerzaVertical2;
		}
		set{
			fuerzaVertical2=value;
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

