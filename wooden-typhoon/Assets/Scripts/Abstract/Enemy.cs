﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(StateMachine))]
public class Enemy : MonoBehaviour {

	public int health = 30;

	protected GameObject thePlayer;

	protected Rigidbody2D myRigidBody;
	protected Hurtbox myHurtbox;
	protected StateMachine myStateMachine;

	public void Start () {
		thePlayer = GameObject.Find("Player");
	
		myRigidBody = GetComponent<Rigidbody2D>();
		myHurtbox = GetComponent<Hurtbox>();
		myStateMachine = GetComponent<StateMachine>();

		myHurtbox.onHit += myHurtbox.ApplyMutualRecoil;
		myHurtbox.onHit += checkDie;

		myStateMachine.SetState(Idle);
	}

    private void checkDie(Hitbox other)
    {
		if (myHurtbox.totalDamage >= health)
		{
			GameObject.Destroy(gameObject);
		}
    }

    private bool Idle(StateMachine stateM, int frameNo)
    {
		myRigidBody.velocity = Vector2.right * 4 * Mathf.Sin(frameNo / 15f); 
		myRigidBody.velocity += Vector2.up * 4 * Mathf.Cos(frameNo / 15f); 
		return false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}