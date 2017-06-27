
using UnityEngine;
using UnityEngine.UI;
public class UpdateLanding : MonoBehaviour {

	private Text imagen;

	void Awake () {
		imagen=GetComponent<Text>();
		ColisionJugador.onUpdateGuiAterrizajes+=OnUpdateAterrizajes;
	}
	

	void OnUpdateAterrizajes (int _aterrizajes) {
		imagen.text=_aterrizajes.ToString();
	}
}
