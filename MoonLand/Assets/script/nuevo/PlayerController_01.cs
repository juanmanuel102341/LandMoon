using UnityEngine;

public class PlayerController_01 : MonoBehaviour {
	public float velocityRotacion;
	public float velocity;


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
	
		//print("arriba "+acumuladorFuerzaEjeVertical);
		//print("player velocity vertical "+Calc());
	}
	float Calc(){
		return verticalSpeed-compGravedad.DistanciaRec;
	}
	void Teclas(){
		if(Input.GetButton("arriba")){
			acumuladorFuerzaEjeVertical=Input.GetAxis("arriba")*velocity;


			rbody.transform.Translate(Vector2.up*acumuladorFuerzaEjeVertical*Time.deltaTime);
			verticalSpeed+=acumuladorFuerzaEjeVertical*Time.deltaTime;
		
		}
		if(Input.GetButton("arriba")){
			compGravedad.DistanciaRec=Calc();
			//acumuladorFuerzaEjeVertical=0;
			//verticalSpeed=0;
		//	print("suelto arriba");
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
	public float SpeedPlayer{
		get{
			return verticalSpeed;
		}

	}
}
