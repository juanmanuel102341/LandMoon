
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuVuelta : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void OnMenuVuelta_01(){
		print("menu");
		SceneManager.LoadScene("menu");

	}
}
