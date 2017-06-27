
using UnityEngine;
using UnityEngine.UI;
public class Fill : MonoBehaviour {
	public SpriteRenderer spr;


	private float widthTotal;
	//private float currentWhidth=0;
//	private float time=0;
//	private float frame;
//	public Timer timer_comp;
	//private bool active=false;
	private bool finish=false;
	private string namePlataforma;
	private string myName;
	private bool fin=false;

	void Awake () {
		
		fin=false;
		myName=GetComponent<Transform>().name;
	//	widthTotal=GetComponent<Transform>().localScale.x;//guardo ancho
		print("name "+myName);
		//GetComponent<Transform>().localScale=new Vector2(0,GetComponent<Transform>().localScale.y);
		//ColisionJugador.aterrizaje+=onContactoIn;//metodo q se activa cuando player entra en contacto con la plataforma
	//	ColisionJugador.colisionFuera+=onContactoOut;
		ColisionJugador.OnPlataformaContacto+=OnFinish;
		//ColisionJugador.OnPlataformaContacto+=onReset;
		//float t=timer_comp.timeAterrizaje*0.01f;//
		//frame=t/widthTotal;//tiempo x cada pixel
	//	print("frame "+frame);
	}
	



	void OnFinish(string _name){
		if(_name==myName){	
		//finish=true;
		print("desde fill aterrizaje finalizado ");
		print("plataforma potencial "+_name);
		spr.color=Color.green;
			fin=true;
		}
	}
	public bool Deactive{
		get{
			return fin;
		}
	}
	public void Reset(){

		if(fin){
			print("reseteo");
			fin=false;
			spr.color=Color.white;
		}

	}
}
