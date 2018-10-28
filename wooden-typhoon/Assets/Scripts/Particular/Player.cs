using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	delegate void AddVelocity(Vector2 internalVel);
	AddVelocity addVelocity;

	private Vector2 inputVec = new Vector2();
    private Vector2 internalVel = new Vector2();

	private Rigidbody2D myRigidbody2d;
	private Hurtbox myHurtbox;

    void Start () {
		myRigidbody2d = GetComponent<Rigidbody2D>();
		myHurtbox = GetComponent<Hurtbox>();

		// Manually Destroy Me
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	void Update () {
		inputVec.x = Input.GetAxisRaw("Horizontal");
		inputVec.y = Input.GetAxisRaw("Vertical");

		if (inputVec.magnitude > 1) {
			inputVec /= inputVec.magnitude;
		}
	}

	void FixedUpdate() {
		internalVel *= 0;

		internalVel += inputVec * 4;

		if (addVelocity != null) {addVelocity(internalVel);}
		
		myRigidbody2d.velocity = internalVel;
	}

	
}
