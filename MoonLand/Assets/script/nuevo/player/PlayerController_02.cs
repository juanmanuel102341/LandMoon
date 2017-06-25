using UnityEngine;

public class PlayerController_02 : MonoBehaviour {
	public float velocityRotacion;
	public float velocidad;
	public float frecuenciaPlayer;
	private int vidas=3;
	private float acumuladorFuerzaRotacion=0;
	private int combustible=950;
	private Rigidbody2D rbody;
	private string nombreAxisRotacion="ejeHorizontal";
	private Gravedad_02 compGravedad;
	private int direccion=1;
	private float time;
	private float constanteAcum=0;
	private bool izquierda=false;
	void Awake () {
		rbody=GetComponent<Rigidbody2D>();
		combustible=950;
		compGravedad=GetComponent<Gravedad_02>();
		}
	void Update () {

		Teclas();

	}
	public void Desplazamiento(){

	//	if(compGravedad.FuerzaVertical_prop2<0){
	//		direccion=-1;
	//	}else{
	//		direccion=1;
	//	}

		rbody.AddRelativeForce(Vector2.up*constanteAcum*direccion);
	}
	void Teclas(){
		if(Input.GetButton("arriba")){
//			print("press");
			compGravedad.ActiveKey_prop=true;
			if(compGravedad.MagnitudGravity2<0){
	//actualizo el valor de lo q fue acumulando la gravedad por lo q recorrio de velocidad, si es menor a 0, ya q si no hay gravedad n tiene sentido hacerlo 
	
				compGravedad.MagnitudGravity2+=velocidad;
			}
			Desplazamiento();
		}
		if(Input.GetButtonUp("arriba")){
			compGravedad.ActiveKey_prop=false;

		}

		if(Input.GetButton(nombreAxisRotacion)){
			Rotacion();

			}	
		if(Input.GetButtonUp("ejeHorizontal")){
			rbody.angularVelocity=0;

		}

	}
	void Rotacion(){
//		print("transform.rotation.eulerAngles.z "+transform.rotation.eulerAngles.z);
		if(Input.GetAxisRaw(nombreAxisRotacion)<0&&transform.rotation.eulerAngles.z<90){
		//rotacion  izquierda
//			print("izquierda activo");
			izquierda=true;
		}

		if(Input.GetAxisRaw(nombreAxisRotacion)>0&&transform.rotation.eulerAngles.z>=270){
			//rotacion derecha
			//si apreto a la derecha y es mayor a 270 , inicia rotacion derecha
			//	print("derecha activa");
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
