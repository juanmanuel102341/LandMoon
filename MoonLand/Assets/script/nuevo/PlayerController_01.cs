using UnityEngine;

public class PlayerController_01 : MonoBehaviour {
	public float velocityRotacion;
	public float velocity;

	private float acumuladorFuerzaEjeVertical=0;
	private float acumuladorFuerzaRotacion=0;
	private float fuerzaRotacion=0;
	private int combustible=950;
	private Rigidbody2D rbody;
	private string nombreAxisRotacion="ejeHorizontal";
	private bool izquierda=false;
	void Awake () {
		rbody=GetComponent<Rigidbody2D>();
		acumuladorFuerzaEjeVertical=0;
		fuerzaRotacion=0;
		combustible=950;
		izquierda=false;
	}
	void Update () {
	
		Teclas();

	

	}
	void Teclas(){
		if(Input.GetButton("arriba")){
			acumuladorFuerzaEjeVertical=Input.GetAxis("arriba")*velocity;
		//	print("arriba "+acumuladorFuerzaEjeVertical);
			rbody.transform.Translate(Vector2.up*acumuladorFuerzaEjeVertical*Time.deltaTime);
		}
		if(Input.GetButton("arriba")){
			acumuladorFuerzaEjeVertical=0;
			print("suelto arriba");
		}
		//print("transform.rotation.eulerAngles.z "+transform.rotation.eulerAngles.z);
		//print("Input.GetAxisRaw(nombreAxisRotacion) "+Input.GetAxisRaw(nombreAxisRotacion));
		if(Input.GetButton(nombreAxisRotacion)){
			if(Input.GetAxisRaw(nombreAxisRotacion)<0&&transform.rotation.eulerAngles.z<90){
				//si apreto ala izquierda y la posicion de euler es menor a 90 se activa booleano d rotacion izquierda
				//hago esto para cuando llego al limite de la derecha(euler>270) pueda volver a rotar para la izquierda ya q sn lo
				//pongo no lo puedo hacer o no funciona el limite 

				print("izquierda activo");
				izquierda=true;
			}

			if(Input.GetAxisRaw(nombreAxisRotacion)>0&&transform.rotation.eulerAngles.z>=270){
				//si apreto a la derecha y es mayor a 270 , inicia rotacion derecha
				print("derecha activa");
				izquierda=false;
			}
		
			if(transform.rotation.eulerAngles.z<90||Input.GetAxisRaw(nombreAxisRotacion)>0&&
				izquierda||transform.rotation.eulerAngles.z>270||transform.rotation.eulerAngles.z==0||
				Input.GetAxisRaw(nombreAxisRotacion)<0&&izquierda==false){

				//print("Input.GetAxisRaw(nombreAxisRotacion) "+Input.GetAxisRaw(nombreAxisRotacion));
				//print("transform.rotation.eulerAngles.z "+transform.rotation.eulerAngles.z);
				acumuladorFuerzaRotacion=Input.GetAxisRaw(nombreAxisRotacion)*velocityRotacion*-1;
				rbody.angularVelocity=acumuladorFuerzaRotacion;

				}else{
						rbody.angularVelocity=0;
						//print("limite rotacion");
				}

			}	
		if(Input.GetButtonUp("ejeHorizontal")){
			rbody.angularVelocity=0;

		}

	}
}
