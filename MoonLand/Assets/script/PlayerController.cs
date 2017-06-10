
using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour {
	public float velocity=50;
	public float velocityRotacion;
	public float rotacion=1;
	private bool upMax=false;
	private float height;
	//private bool activePlayer=false;
	private Rigidbody2D rb2d;
	private float impulso=0;
	private float impulsoRotacion;
	public float limiteY;

	public float limiteReset;
	void Awake(){
		rb2d=GetComponent<Rigidbody2D>();
		height=GetComponent<SpriteRenderer>().sprite.rect.height*GetComponent<Transform>().localScale.y;
		print("altura "+height);
	}
	void Start () {

	}



	void Update () {
		
		impulso=Input.GetAxis("vertical")*velocity;

		impulso*=Time.deltaTime;
		//print("flotante "+impulso);

		rb2d.transform.Translate(0,impulso,0);



		//print("rotando "+impulsoRotacion);
//		impulsoRotacion=Input.GetAxis("rotacion");


		if(Input.GetButton("rotacionDerecha")){
		//print("rotando");
		//	impulsoRotacion=-30*Time.deltaTime;
		//	rb2d.AddTorque(impulsoRotacion);	
			rb2d.angularVelocity=-velocityRotacion;		
		}
		if(Input.GetButtonUp("rotacionDerecha")||Input.GetButtonUp("rotacionIzquierda")){
		//	print("rotando");
		//	impulsoRotacion=GetComponent;
		//	rb2d.AddTorque(impulsoRotacion);	
			rb2d.angularVelocity=0;	
		}

		if(Input.GetButton("rotacionIzquierda")){

			rb2d.angularVelocity=velocityRotacion;
		}
	
	}
	public float impulsoUp{

		get{

			return impulso;
		}
	}


}
