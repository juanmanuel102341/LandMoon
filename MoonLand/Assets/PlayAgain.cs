using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {
	public delegate void NuevoJuego();
	public static event NuevoJuego newGame;
	public static event NuevoJuego newGame_Menu;
	void Start () {
		
	}
	


	public void PlayAgain_01(){
		print("nuevo juego");
		newGame();
		//SceneManager.LoadSceneAsync("2");
	}
	public void NewGameMenu(){
		print("nuevo juego desde menu");
		NewGameMenu();
	}
}
