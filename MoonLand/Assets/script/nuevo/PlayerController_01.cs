using UnityEngine;

public class PlayerController_01 : MonoBehaviour {
	public float velocityRotacion;
	public float velocity=0;


	private float verticalSpeed=0;//velocidad vertical
	private int vidas=3;
	private float acumuladorFuerzaEjeVertical=0;
	private float acumuladorFuerzaRotacion=0;
	private int combustible=950;
	private Rigidbody2D rbody;
	private string nombreAxisRotacion="ejeHorizontal";
	//private bool izquierda=false;
	private float distanciaRecorrida;
	private Gravedad compGravedad;
	private Vector2 vspeed;
	public float aceleracion;

	void Awake () {
		rbody=GetComponent<Rigidbody2D>();
		acumuladorFuerzaEjeVertical=0;
		combustible=950;
		compGravedad=GetComponent<Gravedad>();
	//	izquierda=false;
	}
	void Update () {

		Teclas();
		//verticalSpeed
//		print("velocidad obj"+this.rbody.velocity);
//		print("force "+rbody.velocity);
		//print("player velocity vertical "+Calc());
	}
	public void Desplazamiento(){
		
		compGravedad.FuerzaVertical_prop=compGravedad.MagnitudGravity+velocity;
	}
	void Teclas(){
		if(Input.GetButton("arriba")){
			//acumuladorFuerzaEjeVertical=Input.GetAxis("arriba")*velocity;
			velocity+=1.3f*Time.deltaTime;
			//print("fuerzaVertical player"+compGravedad.FuerzaVertical_prop);
			Desplazamiento();
			//print("velocity "+velocity);

			if(	compGravedad.FuerzaVertical_prop>0){
				rbody.AddForce(transform.up*compGravedad.FuerzaVertical_prop);
			//verticalSpeed+=acumuladorFuerzaEjeVertical*Time.deltaTime;
			}
		}
		if(Input.GetButton("arriba")){

			//acumuladorFuerzaEjeVertical=0;
			//verticalSpeed=0;
		//	print("suelto arriba");
			//aceleracion=0;
		}
		//print("transform.rotation.eulerAngles.z "+transform.rotation.eulerAngles.z);
		//print("Input.GetAxisRaw(nombreAxisRotacion) "+Input.GetAxisRaw(nombreAxisRotacion));
		if(Input.GetButton(nombreAxisRotacion)){
			
			if(Input.GetAxisRaw(nombreAxisRotacion)>0){
				//print("Input.GetAxisRaw(nombreAxisRotacion) "+Input.GetAxisRaw(nombreAxisRotacion));
				//print("transform.rotation.eulerAngles.z "+transform.rotation.eulerAngles.z);
				acumuladorFuerzaRotacion=velocityRotacion*-1;
				rbody.angularVelocity=acumuladorFuerzaRotacion;
				}else if(Input.GetAxisRaw(nombreAxisRotacion)<0){
				acumuladorFuerzaRotacion=velocityRotacion;
				rbody.angularVelocity=acumuladorFuerzaRotacion;

						//print("limite rotacion");
			}else{
				rbody.angularVelocity=0;
			}

			}	
		if(Input.GetButtonUp("ejeHorizontal")){
			rbody.angularVelocity=0;

		}

	}
	public int Vidas{
		get{
			return vidas;
		}
		set{
			vidas=value;
		}
	}
	public float MagnitudVelocidad{
		get{
			return velocity;
		}

	}
}
