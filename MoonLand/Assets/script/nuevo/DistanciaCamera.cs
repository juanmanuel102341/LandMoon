
using UnityEngine;

public class DistanciaCamera : MonoBehaviour {
	private Transform transformPlayer;
	public Transform transformPlaneta;
	public float distanciaCamera;
	public delegate void CameraActive();
	public static event CameraActive onCameraActive;
	public static event CameraActive onCameraOut;
	private float distancia;
	private bool active=false;//se activa si se cumple condicion
	//script se ocupa de verificar distancia entre player y planeta y activa camara a traves d evento
	void Awake () {
		transformPlayer=GetComponent<Transform>();
	}
	void DistanciaPlanetaPlayer(){
		
		distancia=Vector2.Distance(transformPlayer.position,transformPlaneta.position);
		print("distancia planeta player "+distancia);
		if(distancia<=distanciaCamera&&active==false){
			//boleano para q no entre todo el tiempo y tb me avse cuando sale de la distancia
			active=true;
			print("distancia activa");
			onCameraActive();//activo eevento de zoom para q aplieque zoom
		}else if(active&&distancia>=distanciaCamera){
			onCameraOut();//activo evento de zoom para q vuelva a la vista normal
			print("camera fuera");
			active=false;//false active para q pueda seguir rastreando distancia
		}
	}

	void Update () {
		DistanciaPlanetaPlayer();
	}
}
