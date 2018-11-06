using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour {

	Weapon activeWeapon;

	void Start() {
		
	}
	
	void Update() {
		if (gameObject.tag == "Player" && Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			PointAt(mousePos);
		}
	}

	void SwitchWeapon(int id) {
		if (activeWeapon.swinging) {return;}
	}

	void PointAt(Vector2 vec) {
		float angle = Mathf.Atan2(vec.y - transform.position.y, vec.x - transform.position.x);
		angle *= 180 / Mathf.PI;
		transform.Rotate(0, 0, angle - transform.eulerAngles.z);
	}
}
