using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy {

	// Use this for initialization
	new void Start () {
		base.Start();

		base.myStateMachine.state = Chase;
		base.myStateMachine.defaultState = Chase;
	}

	Vector2 vec = new Vector2();

    private bool Chase(StateMachine stateM, int frameNo)
    {
        vec = thePlayer.transform.position;
        vec -= (Vector2)transform.position;

        // Magic Numbers Intesify
        vec *= 2 / vec.magnitude;
        
		myRigidBody.velocity = vec; 		
		return false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
