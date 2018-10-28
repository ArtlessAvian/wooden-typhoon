using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hitbox : MonoBehaviour {

    public int damage = 1;

    public delegate void OnHit(Hurtbox other);
    public OnHit onHit;

    private Collider2D myCollider;
    private List<GameObject> ignoreHits = new List<GameObject>();

    void Start () {
        myCollider = GetComponent<Collider2D>();
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
}
