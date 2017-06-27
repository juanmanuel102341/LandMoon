
using UnityEngine;
using UnityEngine.UI;
public class UpdateLife : MonoBehaviour {
	
	private Text imagen;
	// Use this for initialization
	void Awake () {
		imagen=GetComponent<Text>();
		ColisionJugador.OnUpdateLife_gui+=OnUpdateLife;	
	
	}
	
	// Update is called once per frame
	void OnUpdateLife (int numVidas) {
		imagen.text=numVidas.ToString();
	}
}
