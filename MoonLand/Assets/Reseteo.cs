
using UnityEngine;

public class Reseteo : MonoBehaviour {
	public PlayerController_02 pc;
	public ColisionJugador colision;
	private Camera mainCamera;
	public GameObject guiLoose;
	public GameObject guiWin;
	public GameObject guiMenu;
	private GameObject objPadre;
	private bool win=false;
	void Start () {
		if(objPadre==null){
		objPadre=GameObject.FindGameObjectWithTag("gameActive");
		}
		ColisionJugador.juegoTerminado+=InstanciaDefinicion;
		PlayAgain.newGame+=OnNewGame;
		PlayAgain.newGame_Menu+=OnNewGameMenu;
		guiLoose.SetActive(false);

		mainCamera=GetComponent<Camera>();
		print("reset Game");
	
	}
	void ResetGame(){
			pc.CurrentVidas=pc.vidas;//reseteo vidas
		//GameObject [] objs=GameObject.FindGameObjectsWithTag("plataforma_tag");
		//if(objs!=null){
		//for(int i=0;i<objs.Length;i++){
		//reseteamos platformas
		//	objs[i].GetComponent<Fill>().Reset();
		//}
		//}
		//		OnReset("");//evento reseteo fill, para plataformas
		pc.transform.position=colision.GetPosInicial;
		pc.GetComponent<SpriteRenderer>().enabled=true;//activamos render
		pc.GetComponent<Timer>().enabled=true;
		pc.GetComponent<PlayerController_02>().enabled=true;
		pc.GetComponent<Gravedad_02>().enabled=true;

		colision.AterrizajesExitosos=0;//reseto aterrizajes
		mainCamera.orthographicSize=GetComponent<ZoomCamara>().getZoom;//reseteamos zoom al original
		colision.getGameOver=false;
	}
	public void InstanciaDefinicion(bool _win){
		objPadre.SetActive(false);
		win=_win;
		if(_win==false){
		guiLoose.SetActive(true);
		}else{
		guiWin.SetActive(true);
		}
		}
	public void OnNewGame(){
		ResetGame();
		if(win==false){
		guiLoose.SetActive(false);//desactivamos gui
		}
		if(win){
			guiWin.SetActive(false);
		}
			objPadre.SetActive(true);//activamos padre juego
	}
	public void OnNewGameMenu(){
		print("nuevoJuego desde menu");
		guiMenu.SetActive(false);
		objPadre.SetActive(true);
	} 

}
