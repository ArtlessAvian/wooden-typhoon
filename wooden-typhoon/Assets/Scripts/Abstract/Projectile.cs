using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody2D), typeof(StateMachine))]
public class Projectile : MonoBehaviour {

	// public int health = 30;

	// protected GameObject thePlayer;
    public Vector2 myVelocity = new Vector2(3, 0); // Edited by initializer

	protected Rigidbody2D myRigidBody;
	protected Hitbox myHitbox;
    // protected StateMachine myStateMachine;

    public void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myHitbox = GetComponent<Hitbox>();
		// myStateMachine = GetComponent<StateMachine>();

		myHitbox.onHit += deleteSelf;
		// myHurtbox.onHit += checkDie;

		// myStateMachine.SetState(Idle);
	}

	public void FixedUpdate() {
		myRigidBody.velocity = myVelocity;
	}

    private void deleteSelf(Hurtbox other) {
		GameObject.Destroy(gameObject, 1/60f);
	}
}
