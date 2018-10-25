using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollected : MonoBehaviour {

	public Vector3 size = new Vector3(0.5f, 2, 1);
	
	public int preSwingFrames = 0;
	public int followThrough = 30;
	public int activeFrames = 10;

	private bool swinging = false;
	private float swingFrame = 0;

	private Collider2D hitboxCollider;
	private Transform hitboxTransform;

	void Start() {
		// For testers who put "WeaponCollected"s wherever, it'll jump instantly to the player, if its theirs.
		if (tag == "Player") {
			transform.parent = GameObject.Find("Player").transform;
		}		

		hitboxCollider = gameObject.GetComponentInChildren<BoxCollider2D>();
		hitboxTransform = transform.Find("Hitbox"); // Specifically the child
		hitboxTransform.Translate(0, size.y/2f, 0);
		hitboxTransform.localScale = size * 0;
	}

	void FixedUpdate() {
		if (tag == "Player") {
			TemporaryPlayerInput();
		}
		TemporarySwing();
	}

	private void TemporaryPlayerInput() {
		if (!swinging && Input.GetMouseButtonDown(0)) {
			swinging = true;

			Vector3 mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);

			float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
			angle *= 180 / Mathf.PI;
			angle -= 90;
			transform.Rotate(0, 0, angle - transform.eulerAngles.z);
		}
	}

    private void TemporarySwing()
    {
		if (swinging) {
			bool active = swingFrame >= preSwingFrames && swingFrame < preSwingFrames + activeFrames;

			// hitboxTransform.localScale = size * (Input.GetMouseButtonDown(0) ? 1 : 0);
			hitboxTransform.localScale = size * (active ? 1 : 0);
			
			if (swingFrame >= preSwingFrames + followThrough) {
				swinging = false;
				swingFrame = 0;
			}
			// print(swingFrame);
			swingFrame += 1;
		}
    }
}