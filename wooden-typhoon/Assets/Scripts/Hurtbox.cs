using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {

	const int HITBOX_LAYER = 9;
	public int health = 30;
	
	public delegate void OnDie(GameObject obj);
	public OnDie onDie;

	// Use this for initialization
	void Start () {
		onDie = Object.Destroy;
	}

	// Collider2D justHit;
	void OnTriggerEnter2D(Collider2D other)
	{
		// Ask the other how much it should be hit for
		// Somehow :/

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