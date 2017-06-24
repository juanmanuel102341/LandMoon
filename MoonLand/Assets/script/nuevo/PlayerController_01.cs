using UnityEngine;

public class PlayerController_01 : MonoBehaviour {
	public float velocityRotacion;
	public float velocidad;
	public float frecuenciaPlayer;
	private int vidas=3;
	private float acumuladorFuerzaRotacion=0;
	private int combustible=950;
	private Rigidbody2D rbody;
	private string nombreAxisRotacion="ejeHorizontal";
	private Gravedad compGravedad;
	public int direccion=1;
	private float time;
	private float constanteAcum=0;
	void Awake () {
		rbody=GetComponent<Rigidbody2D>();
		combustible=950;
		compGravedad=GetComponent<Gravedad>();
		}
	void Update () {

		Teclas();

	}
	public void Desplazamiento(){

		if(compGravedad.FuerzaVertical_prop2<0){
			direccion=-1;
		}else{
			direccion=1;
		}
		rbody.transform.Translate(Vector2.up*compGravedad.FuerzaVertical_prop2*direccion*Time.deltaTime,Space.Self);

	}
	void Teclas(){
		if(Input.GetButton("arriba")){
//			print("press");
			compGravedad.ActiveKey_prop=true;
			Desplazamiento();
		}
		if(Input.GetButtonUp("arriba")){
			compGravedad.ActiveKey_prop=false;
		//	print("suelto arriba");
		}

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
	void FixedUpdate(){
		time+=Time.deltaTime;
		if(time>frecuenciaPlayer&&compGravedad.ActiveKey_prop==true){
			constanteAcum+=velocidad;
			time=0.0f;
		//	print("acum player "+constanteAcum);
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

	public float MagnitudVelocidad2{
		get{
			return constanteAcum;
		}

	}
}
