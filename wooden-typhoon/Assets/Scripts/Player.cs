using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public PlayerData.PlayerStats stats;
	
	private Rigidbody2D my_rigidbody2D;

	void Start () {
		// Manually Destroy Me
		UnityEngine.Object.DontDestroyOnLoad(this);

		PlayerData data = GameObject.Find("PlayerData").GetComponent<PlayerData>();
		stats = new PlayerData.PlayerStats(data.baseStats);

		my_rigidbody2D = GetComponent<Rigidbody2D>();
		my_rigidbody2D.freezeRotation = true;
	}

	private Vector3 tempVelocity = new Vector3();

	void FixedUpdate() {
		// currentState.run()
		
		tempVelocity.x += Input.GetAxisRaw("Horizontal") * 2;
		tempVelocity.y += Input.GetAxisRaw("Vertical") * 2;

		if (tempVelocity.magnitude > 4 / 0.8)
		{
			tempVelocity *= 4.0f / 0.8f / tempVelocity.magnitude;
		}
		tempVelocity *= 0.8f;
		my_rigidbody2D.MovePosition(transform.position + tempVelocity * Time.fixedDeltaTime);
	}
}
