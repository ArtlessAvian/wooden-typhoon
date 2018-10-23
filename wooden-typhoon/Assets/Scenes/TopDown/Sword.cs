using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	Collider2D hitboxCollider;
	Transform hitboxTransform;
	Vector3 size = new Vector3(0.5f, 2, 1);

	// Use this for initialization
	void Start () {
		hitboxCollider = gameObject.GetComponentInChildren<BoxCollider2D>();
		hitboxTransform = transform.Find("Hitbox"); // Specifically the child
		hitboxTransform.Translate(0, size.y/2f, 0);
		hitboxTransform.localScale = size * 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 mousePos = Input.mousePosition;
 		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		
		float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
		angle *= 180 / Mathf.PI;
		angle -= 90;
		transform.Rotate(0, 0, angle - transform.eulerAngles.z);

		// if (Input.GetMouseButtonDown(0))
		hitboxTransform.localScale = size * (Input.GetMouseButton(0) ? 1 : 0);
	}
}
