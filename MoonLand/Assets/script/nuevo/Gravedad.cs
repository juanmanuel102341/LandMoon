
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

	void Awake(){
		transformPersonaje=GetComponent<Transform>();
		rb=GetComponent<Rigidbody2D>();
		propx=PropX();
		propy=PropY();
		distanceInicial=Vector2.Distance(transformPersonaje.position,transformPlaneta.position);
	}

	float CalcDistance(){
		//distancia entre el personaje y planeta
		//print("distancia entre el planeta y jugador "+Vector2.Distance(transformPersonaje.position,transformPlaneta.position));
		return Vector2.Distance(transformPersonaje.position,transformPlaneta.position);
	}
	float VectorDistance(){
		float currentDistance=Vector2.Distance(transformPersonaje.position,transformPlaneta.position);

		float v=distanceInicial-currentDistance;
		v+=v;
		//distanceInicial=currentDistance;
		return v;		
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
		print("gavedad acum "+VectorDistance());
		rb.transform.Translate(new Vector2(propx,propy)*Time.deltaTime*fuerza,Space.World);//establezco el translate del vector segun las proporciones en x e y y establezco como referencia el mundo sino tengo problemas con la rotacion  

		}

	}


