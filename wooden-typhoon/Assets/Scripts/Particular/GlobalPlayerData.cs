using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GlobalPlayerData : MonoBehaviour {

	// It's definitely not a singleton, I'd call it a Prototype Pattern???
	[Serializable]
	public class PlayerStats {
		public float health = 0;
		public float attack = 0;

		public PlayerStats() {}

		public PlayerStats(PlayerStats toCopy) {
			// Yeah, definitely a prototype
			health = toCopy.health;
			attack = toCopy.attack;
		}

		public void RegenerateStats() {
			health = 10 + UnityEngine.Random.value * 20;
			attack = 3 + UnityEngine.Random.value * 3;
		}

		// // Don't take this seriously.
		// public void LevelUp() {
		// 	health = UnityEngine.Random.value * 3 - 1; // Expected Value of 0.5
		// 	attack = UnityEngine.Random.value * 3 - 1;
		// }
    }

	public bool regenerateOnPlay = true;
	public PlayerStats baseStats = new PlayerStats();

	void Start () {
        // Destroy me on Title Screen
        UnityEngine.Object.DontDestroyOnLoad(this);

		if (regenerateOnPlay) {
			baseStats.RegenerateStats();			
		}
	}
}
