
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

	void Awake(){
		transformPersonaje=GetComponent<Transform>();
		rb=GetComponent<Rigidbody2D>();

		propx=PropX();
		propy=PropY();
	}

	float CalcDistance(){
		//distancia entre el personaje y planeta
		return Vector2.Distance(transformPersonaje.position,transformPlaneta.position);
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

		rb.transform.Translate(new Vector2(propx,propy)*Time.deltaTime*fuerza,Space.World);//establezco el translate del vector segun las proporciones en x e y y establezco como referencia el mundo sino tengo problemas con la rotacion  

		}

	}


