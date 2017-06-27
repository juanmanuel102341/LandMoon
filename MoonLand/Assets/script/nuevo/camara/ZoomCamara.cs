using UnityEngine;

public class ZoomCamara : MonoBehaviour {
	// script se encarga del zoom de la camara
	public float zoom;
	private float initialZoom;
	private Camera camara;
	void Awake () {
		camara=	GetComponent<Camera>();
		initialZoom=camara.orthographicSize;
		DistanciaCamera.onCameraActive+=OnCamaraIn;//evento viene de script distancia camara del player, activa zoom	
		DistanciaCamera.onCameraOut+=OnCamaraOut;
	}

	void OnCamaraIn(){
		camara.orthographicSize=zoom;
		print("camara mundo");	
	}
	void OnCamaraOut(){
		print("camara out");
		camara.orthographicSize=initialZoom;
	} 
	public float getZoom{
		get{
			return initialZoom;
		}
	}

}
