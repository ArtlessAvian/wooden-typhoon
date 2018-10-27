using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] objs;
	// Use this for initialization
	void Start () {
		int rand = Random.Range(0, objs.Length);
		Instantiate(objs[rand], transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
