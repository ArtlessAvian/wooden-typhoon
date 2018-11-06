using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StateMachine : MonoBehaviour {

    public delegate bool State(StateMachine stateM, int frameNo);

    // Don't set these directly i guess
	public State defaultState;
    public State state;

    private int frameNo = 0;

	private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        for (int i = 0; i < 10; i++) {
            // Exit if changed state
            if (!state(this, frameNo))
            {
                frameNo++;
                break;
            }
        }
	}

    public void SetState(State newState) {
        if (defaultState == null) {
            defaultState = newState;
        }
        state = newState;
        frameNo = 0;
    }

    public void ResetDefault() {
        state = defaultState;
    }
}
