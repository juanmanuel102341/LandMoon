
using UnityEngine;
using UnityEngine.UI;
public class UpdateVector : MonoBehaviour {
	private Text imagen;
	private Vector2 pos;
	private Vector2 distMenor;
	public PlayerController_02 pc;
	// Use this for initialization
	void Start () {
		imagen=GetComponent<Text>();
		pos.x=pc.GetPositionPLayer.x;
		pos.y=pc.GetPositionPLayer.y;
		distMenor.x=pos.x-Distancias.positionMenor.x;
		distMenor.y=pos.y-Distancias.positionMenor.y;
		print("posicion diferrencia "+distMenor);
	}
	
	// Update is called once per frame
	void Update () {
		pos.x=pc.GetPositionPLayer.x;
		pos.y=pc.GetPositionPLayer.y;
		distMenor.x=pos.x-Distancias.positionMenor.x;
		distMenor.y=pos.y-Distancias.positionMenor.y;
		imagen.text=distMenor.ToString();		
	}
}
