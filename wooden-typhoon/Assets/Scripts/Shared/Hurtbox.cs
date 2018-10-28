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

    private Collider2D myCollider;

    void Start () {
        myCollider = GetComponent<Collider2D>();
        onHit += tempOnHit;
	}

    private void tempOnHit(Hitbox other)
    {
        print("OOF " + other.damage);
    }

    void Update () {

	}

    void FixedUpdate()
    {
        if (iFrames > 0) {
            iFrames--;
        }        
    }

    private bool confirmHit(Hitbox hitbox)
    {
        return iFrames <= 0;
    }

    const int HITBOX_LAYER = 9;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != HITBOX_LAYER) {return;}

        Hitbox otherHitbox = other.gameObject.GetComponentInParent<Hitbox>();
        print(gameObject.name + " hit by " + other.gameObject.name);

        if (confirmHit(otherHitbox))
        {
            otherHitbox.onHit(this);
            onHit(otherHitbox);
        }
    }
}
