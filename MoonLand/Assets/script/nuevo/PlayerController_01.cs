using UnityEngine;

public class PlayerController_01 : MonoBehaviour {
	public float velocityRotacion;
	private float velocity=0;


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
	public int direccion=1;

	void Awake () {
		rbody=GetComponent<Rigidbody2D>();
		acumuladorFuerzaEjeVertical=0;
		combustible=950;
		compGravedad=GetComponent<Gravedad>();
	//	izquierda=false;
		velocity=0;
	}
	void Update () {

		Teclas();
		//verticalSpeed
//		print("velocidad obj"+this.rbody.velocity);
//		print("force "+rbody.velocity);
		//print("player velocity vertical "+Calc());
	}
	public void Desplazamiento(){
		
		velocity+=0.2f*Time.deltaTime;
	//	print("velocity "+velocity);
		if(compGravedad.FuerzaVertical_prop<0){
			direccion=-1;
		}else{
			direccion=1;
		}

		if(compGravedad.FuerzaVertical_prop>0){
			print("gana fuerza player");
			rbody.AddRelativeForce(transform.up*compGravedad.FuerzaVertical_prop*direccion);

		}
	}
	void Teclas(){
		//print("boleeano "+	compGravedad.ActiveKey_prop);

		//print("compGravedad.FuerzaVertical_prop "+compGravedad.FuerzaVertical_prop);	
		if(Input.GetButton("arriba")){
			print("press");
			//acumuladorFuerzaEjeVertical=Input.GetAxis("arriba")*velocity;
			compGravedad.ActiveKey_prop=true;
		
			//print("fuerzaVertical player"+compGravedad.FuerzaVertical_prop);
			Desplazamiento();
			//print("arriba"+velocity);
		
			//verticalSpeed+=acumuladorFuerzaEjeVertical*Time.deltaTime;

		}
		if(Input.GetButtonUp("arriba")){
			
			compGravedad.ActiveKey_prop=false;
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
