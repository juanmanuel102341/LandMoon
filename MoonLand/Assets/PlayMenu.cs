
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayMenu : MonoBehaviour {


	void Start () {
		
	}
	
	// Update is called once per frame
	public void PlayMenu_01(){
		SceneManager.LoadSceneAsync(1);
	}
}