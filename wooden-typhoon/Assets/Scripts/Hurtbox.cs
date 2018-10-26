﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {

	const int HITBOX_LAYER = 9;
	public int health = 30;
	
	public delegate void OnDie(GameObject self, Collider2D other);
	public OnDie onDie;
	public delegate void OnHit(GameObject self, Collider2D other);
	public OnHit onHit;

	public int redFlash = -1;
	public Vector2 knockback = new Vector2();

	private Rigidbody2D my_rigidbody2d;
	private SpriteRenderer my_spriteRenderer;

	// Use this for initialization
	void Start () {
		onDie = TempDie;
		onHit = DefaultHit;
		// 
		my_rigidbody2d = GetComponent<Rigidbody2D>();
		my_spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void DefaultHit(GameObject self, Collider2D other)
    {
		redFlash = 5;
		my_spriteRenderer.color = new Color(1,0,0,1);
    }

    private void TempDie(GameObject self, Collider2D other)
    {
		GameObject.Destroy(this);
    }

    public void moveKnockback()
	{
		// Only one Move Position can be made per Fixed Update
		my_rigidbody2d.MovePosition(my_rigidbody2d.position + knockback * Time.fixedDeltaTime);
		
		// Magic Number Time
		// Sqr magnitude is a minor efficiency save
		float magnitude = knockback.magnitude;
		if (magnitude > 1)
		{
			knockback *= (magnitude - 1) / magnitude;
		}
		else
		{
			knockback *= 0;
		}
	}

	void Update() {
		if (redFlash > 0) {
			redFlash--;
		}
		if (redFlash == 0) {
			redFlash--;
			my_spriteRenderer.color = new Color(1,1,1,1);
		}
	}

	// Collider2D justHit;
	void OnTriggerEnter2D(Collider2D other)
	{
		// Ask the other how much it should be hit for
		// Somehow :/
		print("hello");
		print(gameObject.name + " hit by " + other.gameObject.name);
		
		if (other.gameObject.layer != HITBOX_LAYER) {return;}
		if (other.tag == tag) {return;} // ignore self collision
		print("damage dealt!");

		// Testing
		
		knockback = transform.position;
		knockback -= (Vector2)other.gameObject.transform.parent.position;
		knockback *= 10 / knockback.magnitude;

		onHit(gameObject, other);
		health -= 5;
		if (health <= 0)
		{
			onDie(gameObject, other);
		}
	}
}