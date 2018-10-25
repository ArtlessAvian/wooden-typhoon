using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D my_rigidbody2D;
    private Rigidbody2D player_rigidbody2D;

    void Start() {
		player = GameObject.Find("Player");

		my_rigidbody2D = GetComponent<Rigidbody2D>();
		player_rigidbody2D = player.GetComponent<Rigidbody2D>();
	}

	private Vector2 helper = new Vector3();

	void FixedUpdate()
	{
		// IDK, dumb behavior
		helper = player_rigidbody2D.position;
		helper -= my_rigidbody2D.position;
		helper /= helper.magnitude;
		helper *= 3;

		my_rigidbody2D.MovePosition(my_rigidbody2D.position + helper * Time.fixedDeltaTime);
	}

}
