using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
	
	public int health = 30;
	
	delegate void OnDie(GameObject obj);
	OnDie onDie;

	// Use this for initialization
	void Start () {
		onDie = Object.Destroy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	const int HITBOX_LAYER = 9;
	// Collider2D justHit;
	void OnTriggerEnter2D(Collider2D other)
	{
		print(gameObject.name + " hit by " + other.gameObject.name);
		
		if (other.gameObject.layer != HITBOX_LAYER) {return;}
		if (other.tag == tag) {return;} // ignore self collision
		print("damage dealt!");

		// Testing
		health -= 5;
		if (health <= 0)
		{
			onDie(gameObject);
		}
	}
}