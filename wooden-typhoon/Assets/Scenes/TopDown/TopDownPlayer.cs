using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour {

	Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		rigidbody2D.freezeRotation = true;
	}
	
	Vector2 vel = new Vector2();
	// Update is called once per frame
	void FixedUpdate () {
		vel.x = Input.GetAxisRaw("Horizontal");
		vel.y = Input.GetAxisRaw("Vertical");
		vel *= 4;

		rigidbody2D.velocity = vel;
	}
}
