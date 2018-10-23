using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {

	Transform playerTransform;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find("Player");
		playerTransform = player.GetComponent<Transform>();
	}

	Vector3 helper = new Vector3();

	// Update is called once per frame
	void Update () {
		// Naive solution
		// I could solve a weird infinte series or something
		// It works fine enough already though

		// Vector3 mousePos = Input.mousePosition;
		// mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		// helper = mousePos;
		// helper += playerTransform.position * 7;
		helper = playerTransform.position;
		// helper /= 8;

		helper.z = -10;
		transform.position = helper;
	}
}
