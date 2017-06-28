using UnityEngine;

public class PlayerController_02 : MonoBehaviour {
	public float velocityRotacion;
	public float velocidad;
	public float frecuenciaPlayer;
	public int vidas;
	private int currentVidas;
	private float acumuladorFuerzaRotacion=0;
	private int combustible=950;
	private Rigidbody2D rbody;
	private string nombreAxisRotacion="ejeHorizontal";
	private Gravedad_02 compGravedad;
	private int direccion=1;
	private float time;
	private float constanteAcum=0;
	private bool izquierda=false;
	public delegate void SoundCall();
	public static event SoundCall Down;//evento creado para informar a sonido
	public static event SoundCall Up;
	public delegate void UpdateGuiVelocity(Vector2 num);
	public static  event UpdateGuiVelocity OnUpdateVelocity_gui;

	//public Boundary boundarys;
	private bool fronteraActive=false;
	private string currentFrontera;

	void Awake () {
		currentVidas=vidas;
		rbody=GetComponent<Rigidbody2D>();
		combustible=950;
		compGravedad=GetComponent<Gravedad_02>();

	}
	void Update () {

		Teclas();

	}
	public void Desplazamiento(){
		

		rbody.AddRelativeForce(Vector2.up*constanteAcum*direccion);
	}
	void Teclas(){
		if(this.enabled){
		OnUpdateVelocity_gui(rbody.velocity);
		}

	
		if(Input.GetButton("arriba")&&!fronteraActive){
//			print("press");
			Down();//informa a sonido tecla presionada
			compGravedad.ActiveKey_prop=true;
			if(compGravedad.MagnitudGravity2<0){
	//actualizo el valor de lo q fue acumulando la gravedad por lo q recorrio de velocidad, si es menor a 0, ya q si no hay gravedad n tiene sentido hacerlo 
	
				compGravedad.MagnitudGravity2+=velocidad;
			}
			Desplazamiento();
		}else if(fronteraActive){
			print("limite "+currentFrontera);
			rbody.velocity=new Vector2(0.0f,0.0f);
			print("transform.rotation.eulerAngles.z "+transform.rotation.eulerAngles.z);
			print("gravedad "+compGravedad.MagnitudGravity2);
	
			switch(currentFrontera)
			{
			case "limite_i":
				if(compGravedad.MagnitudGravity2<-8.0f||transform.rotation.eulerAngles.z>359){
					//actua gravedad o euler x rotacion 

					compGravedad.MagnitudGravity2=0;//reseteamos gravedad para q no salga disparado
					print("desbloqueo");
					fronteraActive=false;
					currentFrontera="";
				}
				break;

			case"limite_d":
				if(compGravedad.MagnitudGravity2<-8.0f||transform.rotation.eulerAngles.z<90){
					compGravedad.MagnitudGravity2=0;
					fronteraActive=false;
					currentFrontera="";

				}
				break;
			case"limite_up":
				if(compGravedad.MagnitudGravity2<-8.0f||transform.rotation.eulerAngles.z<315.0f&&transform.rotation.eulerAngles.z>90||transform.rotation.eulerAngles.z>50.0f&&transform.rotation.eulerAngles.z<90.0f){
					compGravedad.MagnitudGravity2=0;
					fronteraActive=false;
					currentFrontera="";

				}
				break;
			case"limite_down":
				if(compGravedad.MagnitudGravity2<-8.0f){
					compGravedad.MagnitudGravity2=0;
					fronteraActive=false;
					currentFrontera="";

				}
				break;

			}

		}
		if(Input.GetButtonUp("arriba")){
			compGravedad.ActiveKey_prop=false;
			Up();//informa a sonido tecla levantada
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
	void OnTriggerEnter2D(Collider2D obj){
		switch(obj.tag){

		case"limite_i":
			fronteraActive=true;
			currentFrontera=obj.tag;
			print("Frontera "+fronteraActive);
			print("currentFrontera "+currentFrontera);
			break;
		
		case"limite_d":
			
			fronteraActive=true;
			currentFrontera=obj.tag;
			print("Frontera "+fronteraActive);
			print("currentFrontera "+currentFrontera);
			break;

		case"limite_up":

			fronteraActive=true;
			currentFrontera=obj.tag;
			print("Frontera "+fronteraActive);
			print("currentFrontera "+currentFrontera);
			break;
		case"limite_down":

			fronteraActive=true;
			currentFrontera=obj.tag;
			print("Frontera "+fronteraActive);
			print("currentFrontera "+currentFrontera);
			break;
		}
	}

	public float MagnitudVelocidad2{
		get{
			return constanteAcum;
		}

	}
	public int CurrentVidas{
		get{
			return currentVidas;
		}
		set{
			currentVidas=value;
		}
	}
	public Vector2 GetPositionPLayer{
		get{
			return transform.position;
		}

	}
}
