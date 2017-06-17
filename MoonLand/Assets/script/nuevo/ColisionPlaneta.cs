using UnityEngine;

public class ColisionPlaneta : MonoBehaviour {
	public delegate void Deteccion();
	public static  event Deteccion onDeteccion;

	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D c){
	print("colision");

		onDeteccion();
		//c.GetComponent<Rigidbody2D>().gravityScale*=2;
		//	c.GetComponent<PlayerController>().velocity=20;
	}
}
