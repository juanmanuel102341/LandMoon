
using UnityEngine;
using UnityEngine.UI;
public class UpdateVelocity : MonoBehaviour {
	//private Gravedad_02 current;
	private Text imagen;
	// Use this for initialization
	void Awake () {
		imagen=GetComponent<Text>();
		//current=GameObject.FindGameObjectWithTag("Player").GetComponent<Gravedad_02>();
		PlayerController_02.OnUpdateVelocity_gui+=OnUpdate;
	}
	

	void  OnUpdate(Vector2 _velocity) {
		imagen.text=_velocity.ToString();
	}
}
