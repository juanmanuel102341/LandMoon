using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Rotacion : MonoBehaviour {
	private Rigidbody2D rb;
	public float velocity;
	// Use this for initialization
	void Awake () {
		rb=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		
		rb.transform.Rotate(Vector3.forward*velocity*Time.deltaTime);
	}
}
