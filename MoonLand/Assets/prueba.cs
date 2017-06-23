using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class prueba : MonoBehaviour {
	public float v; 
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate(){

		rb.AddForce(Vector2.down*v*Time.deltaTime);
	}
}