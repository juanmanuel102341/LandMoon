
using UnityEngine;
using UnityEngine.UI;
public class Sound : MonoBehaviour {
	private bool on=false;
	// Use this for initialization
	void Start () {
		Sonido.soundOn=true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SoundOf(){
		if(on==false){
			print("sonido of");
			Sonido.soundOn=false;
		GetComponent<Image>().color=Color.red;
			on=true;
			PlayerPrefs.SetInt("sonidoPlayer",0);

		}else if(on){
			print("sonido on");
			GetComponent<Image>().color=Color.green;
			on=false;
			Sonido.soundOn=true;
			PlayerPrefs.SetInt("sonidoPlayer",1);
		}
	}
}
