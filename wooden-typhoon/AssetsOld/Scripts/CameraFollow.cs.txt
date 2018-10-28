using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject playerObject;

    void Start () {
		playerObject = GameObject.Find("Player");
	}
	
	Vector3 helper = new Vector3();

	void Update () {
		helper.x = playerObject.transform.position.x;
		helper.y = playerObject.transform.position.y;
		helper.z = -10;
		transform.position = helper;
	}
}
