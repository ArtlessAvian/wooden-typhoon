using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(StateMachine))]
public class Player : MonoBehaviour {

    public GlobalPlayerData.PlayerStats stats;
	
	private Vector2 inputVec = new Vector2();

	private Rigidbody2D myRigidbody2d;
	private Hurtbox myHurtbox;
	private StateMachine myStateMachine;
	private SpriteRenderer mySpriteRenderer;

    void Start () {
		myRigidbody2d = GetComponent<Rigidbody2D>();
		myHurtbox = GetComponent<Hurtbox>();
		myStateMachine = GetComponent<StateMachine>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();

		// Manually Destroy Me
		UnityEngine.Object.DontDestroyOnLoad(this);

		GlobalPlayerData data = GameObject.Find("GlobalPlayerData").GetComponent<GlobalPlayerData>();
		stats = new GlobalPlayerData.PlayerStats(data.baseStats);

		myStateMachine.SetState(WalkState);
		myHurtbox.onHit += myHurtbox.ApplyMutualRecoil;
	}

	private Color iFrameColor = new Color(1, 1, 1, 1);

    void Update () {
		inputVec.x = Input.GetAxisRaw("Horizontal");
		inputVec.y = Input.GetAxisRaw("Vertical");

		if (inputVec.magnitude > 1) {
			inputVec /= inputVec.magnitude;
		}

		if (myHurtbox.iFrames > 0) {
			iFrameColor.a = 1 - ((myHurtbox.iFrames % 4 > 2) ? 1 : 0); // wow
			mySpriteRenderer.color = iFrameColor;
		}
	}

	bool WalkState(StateMachine stateM, int frameNo) {
		myRigidbody2d.velocity = inputVec * 5;

		return false;
	}
}
