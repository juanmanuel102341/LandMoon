using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float velocity=50;
	private float time;
	// Use this for initialization
	private Rigidbody2D rb2d;
	private float impulso=0;
	void Awake(){
		rb2d=GetComponent<Rigidbody2D>();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//	time+=Time.deltaTime;

	
			print("upppp");
		impulso=Input.GetAxis("vertical")*velocity;

			

		impulso*=Time.deltaTime;

		print("flotante "+impulso);
				

		rb2d.transform.Translate(0,impulso,0);
	


	}
}
