
using UnityEngine;

public class DistanciaCamera : MonoBehaviour {
	public Transform transformPlayer;
	public Transform transformPlaneta;

	public delegate void CameraActive();
	public static event CameraActive onCameraActive;
	public static event CameraActive onCameraOut;
	//private float distancia;
	//private bool active=false;//se activa si se cumple condicion
	//script se ocupa de verificar distancia entre player y planeta y activa camara a traves d evento
	void Awake () {



	}
	void OnTriggerEnter2D(){
		print("zona target in");
		//active=true;
		onCameraActive();//activo eevento de zoom para q aplieque zoom
	}
	void OnTriggerExit2D(){
		print("zona target in");
		onCameraOut();//activo evento de zoom para q vuelva a la vista normal
		//			print("camera fuera");
		//active=false;
	}


}
