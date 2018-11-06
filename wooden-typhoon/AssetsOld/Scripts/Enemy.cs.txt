using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D my_rigidbody2D;
	private Hurtbox my_hurtbox;
    private Rigidbody2D player_rigidbody2D;

    void Start() {
		player = GameObject.Find("Player");

		my_rigidbody2D = GetComponent<Rigidbody2D>();
		my_hurtbox = GetComponent<Hurtbox>();
		player_rigidbody2D = player.GetComponent<Rigidbody2D>();
	}

    private Vector2 helper = new Vector3();

	void FixedUpdate()
	{
		if (my_hurtbox.knockback.x != 0 || my_hurtbox.knockback.y != 0) {
			my_hurtbox.moveKnockback();
			return;
		}

		// IDK, dumb behavior
		helper = player_rigidbody2D.position;
		helper -= my_rigidbody2D.position;
		helper /= helper.magnitude;
		helper *= 3;

		my_rigidbody2D.MovePosition(my_rigidbody2D.position + helper * Time.fixedDeltaTime);
	}

}
