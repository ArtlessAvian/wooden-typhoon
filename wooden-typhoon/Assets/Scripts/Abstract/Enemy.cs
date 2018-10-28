using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(StateMachine))]
public class Enemy : MonoBehaviour {

	private GameObject thePlayer;

	private Rigidbody2D myRigidBody;
	private Hurtbox myHurtbox;
	private StateMachine myStateMachine;

	void Start () {
		thePlayer = GameObject.Find("Player");
	
		myRigidBody = GetComponent<Rigidbody2D>();
		myHurtbox = GetComponent<Hurtbox>();
		myStateMachine = GetComponent<StateMachine>();

		myHurtbox.onHit += myHurtbox.ApplyMutualRecoil;
		myStateMachine.SetState(Idle);
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
