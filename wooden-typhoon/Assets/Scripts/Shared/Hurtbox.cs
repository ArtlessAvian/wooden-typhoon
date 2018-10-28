using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hurtbox : MonoBehaviour {

    // Passively gets hit by hitboxes

    public int iFrames = 0;

    public delegate void OnHit(Hitbox other);
    public OnHit onHit;

    private Vector2 knockback = new Vector2();

    private Rigidbody2D myRigidbody2D;
    private Collider2D myCollider;
    private StateMachine myStateMachine;

    void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myStateMachine = GetComponent<StateMachine>();
        onHit += tempOnHit;
	}

    public void tempOnHit(Hitbox other) {
        print("OOF");
    }

    public void ApplyMutualRecoil(Hitbox other) {
        print("apply mutual");
        knockback = transform.position;
        if (other.floatingHitbox) {
            knockback -= (Vector2)other.transform.position;
        } else {
            knockback -= (Vector2)other.transform.parent.position;
        }

        knockback /= knockback.magnitude;
        // Magic Numbers Intesify
        other.receivedKnockback = knockback * -5;
        knockback *= 20; 

        if (tag == "Player") {
            iFrames = 30;
        }

        myStateMachine.SetState(KnockbackRecoil);
        other.GetComponentInParent<StateMachine>().SetState(other.KnockbackRecoil);
    }

    private bool KnockbackRecoil(StateMachine stateM, int frameNo) {
        if (frameNo > 10)
        {
            myRigidbody2D.velocity *= 0;
            stateM.state = stateM.defaultState;
            return true;
        }
        else
        {
            myRigidbody2D.velocity = knockback;
            knockback *= 0.7f; // did someone say magic number? A good feel is between 0.5 and 0.9 so far.
            return false;
        }
    }

    void FixedUpdate() {
        if (iFrames > 0) {
            iFrames--;
        }        
    }

    private bool confirmHit(Hitbox hitbox) {
        return iFrames <= 0;
    }

    const int HITBOX_LAYER = 9;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer != HITBOX_LAYER) {return;}

        Hitbox otherHitbox = other.gameObject.GetComponentInParent<Hitbox>();
        print(gameObject.name + " hit by " + other.gameObject.name);

        if (confirmHit(otherHitbox))
        {
            otherHitbox.onHit(this);
            onHit(otherHitbox);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        OnTriggerEnter2D(other);
    }
}
