
using UnityEngine;

public class MovimientoCamara : MonoBehaviour {
	public Transform transformPlayer;
	private Transform transformCamera;
	void Awake () {
		transformCamera=GetComponent<Transform>();
	}
	

	void Update () {
		transformCamera.position=new Vector3(transformPlayer.position.x,transformPlayer.position.y,transformCamera.position.z);
	}
}
