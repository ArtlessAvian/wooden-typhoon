using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hitbox : MonoBehaviour {

    // If the hitbox isnt attached to a child of a GameObject
    // Also, if you see this, reminder to make projectiles
    public bool floatingHitbox = false;
    
    public int damage = 1;
    public Vector2 receivedKnockback = new Vector2();

    public delegate void OnHit(Hurtbox other);
    public OnHit onHit;

    private List<GameObject> ignoreHits = new List<GameObject>();
    
    private Collider2D myCollider;
    private Rigidbody2D myRigidbody2D;

    void Start () {
        myCollider = GetComponent<Collider2D>();
        myRigidbody2D = GetComponentInParent<Rigidbody2D>();
        
        onHit += tempOnHit;
	}

	void Update () {

	}

    public void Activate(Vector2 vec) {
        transform.localScale = vec;
    }
    
    public void Deactivate() {
        transform.localScale = Vector2.zero;
        ignoreHits.Clear();
    }

    // Hitboxes can only hit Hurtboxes, and are the only thing to hit Hurtboxes
    // void onTriggerEnter2D(Collider2D other)
    // {
    //     print("hey whats up");
    //     Hurtbox otherHurtbox = other.gameObject.GetComponentInParent<Hurtbox>();
    //     // ask the hurtbox if it actually hit it
    //     if (otherHurtbox.confirmHit(this))
    //     {
    //         onHit(this, otherHurtbox);
    //         otherHurtbox.onHit(otherHurtbox, this);
    //     }
    // }

    void tempOnHit(Hurtbox other)
    {
        print(name + " hit something!");
    }

    internal bool KnockbackRecoil(StateMachine stateM, int frameNo)
    {
        if (frameNo > 6)
        {
            myRigidbody2D.velocity *= 0;
            stateM.state = stateM.defaultState;
            return true;
        }
        else
        {
            myRigidbody2D.velocity = receivedKnockback;
            receivedKnockback *= 0.7f; // did someone say magic number? A good feel is between 0.5 and 0.9 so far.
            return false;
        }
    }
}
