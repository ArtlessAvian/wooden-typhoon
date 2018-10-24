using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// public interface PlayerState {
	// 	void enter();
	// 	void run();
	// }

	// public List<PlayerState> states = new List<PlayerState>();
	// PlayerState currentState;

	private Rigidbody2D my_rigidbody2D;

	void Start () {
		// Manually Destroy Me
		UnityEngine.Object.DontDestroyOnLoad(this);

		my_rigidbody2D = GetComponent<Rigidbody2D>();
		my_rigidbody2D.freezeRotation = true;
	}

	void FixedUpdate() {
		// currentState.run()
	}

	private Vector3 tempVelocity = new Vector3();

	void Update () {
		tempVelocity.x += Input.GetAxisRaw("Horizontal") * 2;
		tempVelocity.y += Input.GetAxisRaw("Vertical") * 2;

		if (tempVelocity.magnitude > 4 / 0.8)
		{
			tempVelocity *= 4.0f / 0.8f / tempVelocity.magnitude;
		}
		tempVelocity *= 0.8f;

		my_rigidbody2D.velocity = tempVelocity;
	}

	// class Idle : PlayerScript {

	// }
}
