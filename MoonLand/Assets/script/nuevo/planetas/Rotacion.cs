using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody2D))]
public class Rotacion : MonoBehaviour {
	private Rigidbody2D rb;
	public float velocity;
	private Transform transform;
	// Use this for initialization
	void Awake () {
		rb=GetComponent<Rigidbody2D>();
		transform=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update(){
		
	transform.Rotate(Vector3.forward*velocity*Time.deltaTime);
	}
}
