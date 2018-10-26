using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public PlayerData.PlayerStats stats;
	
	private Rigidbody2D my_rigidbody2D;
	private Hurtbox my_hurtbox;

	void Start () {
		// Manually Destroy Me
		UnityEngine.Object.DontDestroyOnLoad(this);

		PlayerData data = GameObject.Find("PlayerData").GetComponent<PlayerData>();
		stats = new PlayerData.PlayerStats(data.baseStats);

		my_rigidbody2D = GetComponent<Rigidbody2D>();
		my_rigidbody2D.freezeRotation = true;
		my_hurtbox = GetComponent<Hurtbox>();

		my_hurtbox.onHit += ReceiveHit;
		my_hurtbox.onDie = TempDie;
	}

	private Vector2 tempVelocity = new Vector3();
    
    void FixedUpdate() {

		if (my_hurtbox.knockback.x != 0 || my_hurtbox.knockback.y != 0) {
			my_hurtbox.moveKnockback();
			return;
		}

		// currentState.run()
		
		// tempVelocity.x += Input.GetAxisRaw("Horizontal") * 2;
		// tempVelocity.y += Input.GetAxisRaw("Vertical") * 2;
		tempVelocity.x = Input.GetAxisRaw("Horizontal");
		tempVelocity.y = Input.GetAxisRaw("Vertical");

		if (tempVelocity.magnitude != 0) {
			tempVelocity *= 5f / tempVelocity.magnitude;
		}

		// if (tempVelocity.magnitude > 6 / 0.8)
		// {
			// tempVelocity *= 6.0f / 0.8f / tempVelocity.magnitude;
		// }
		// tempVelocity *= 0.8f;
		my_rigidbody2D.MovePosition(my_rigidbody2D.position + tempVelocity * Time.fixedDeltaTime);
	}

	void TempDie(GameObject player, Collider2D other) {
		print("mega oof");
	}

	void ReceiveHit(GameObject player, Collider2D other) {
		print("oof");
	}
}
