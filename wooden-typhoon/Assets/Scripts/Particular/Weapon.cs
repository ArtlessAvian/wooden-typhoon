using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public int preSwingFrames = 0;
    public int activeFrames = 10;
    public int followThrough = 5;
    public Vector2 size = new Vector2(3, 3); // Weapon points to the right

    public bool swinging = false;
    int swingFrame = -1;

    Hitbox myHitbox;

    public void Start() {
        myHitbox = GetComponent<Hitbox>();
        myHitbox.Deactivate();

        transform.localPosition = new Vector2(size.x * 0.5f, 0);
    }

    public void FixedUpdate() {
        if (Input.GetMouseButtonDown(0)){
            swinging = true;
        }
        if (swinging) {

            if (swingFrame >= preSwingFrames + activeFrames + followThrough) {
				swinging = false;
				swingFrame = 0;
            }
            else if (swingFrame >= preSwingFrames + activeFrames) {
                myHitbox.Deactivate();
            }
            else if (swingFrame >= preSwingFrames) {
                myHitbox.Activate(size);
            }

            swingFrame++;
        }
    }
}
