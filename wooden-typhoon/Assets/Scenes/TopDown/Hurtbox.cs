using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {

	int health = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	const int HITBOX_LAYER = 9;

	// Collider2D justHit;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer != HITBOX_LAYER) {return;}
		if (other.tag == tag) {return;} // ignore self collision

		print(gameObject.name + " hit by " + other.gameObject.name);
		
		// Testing
		health -= 5;
		if (health <= 0)
		{
			Object.Destroy(gameObject);
		}
	}

}
