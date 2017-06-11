
using UnityEngine;
public class Frontera : MonoBehaviour {

	public delegate void LimiteFrontera();
	public static  event LimiteFrontera onLimite;

	void Start () {


	}
	

	void OnTriggerEnter2D(Collider2D c){
		print("frontera");
//		onLimite();
		//c.GetComponent<Rigidbody2D>().gravityScale*=2;
	//	c.GetComponent<PlayerController>().velocity=20;
	}
}
