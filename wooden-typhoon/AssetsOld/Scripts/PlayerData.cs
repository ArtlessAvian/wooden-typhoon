using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	[Serializable]
	public class PlayerStats {
		public float health = 0;
		public float attack = 0;

		public PlayerStats() {}

		public PlayerStats(PlayerStats toCopy) {
			health = toCopy.health;
			attack = toCopy.attack;
		}

		public void RegenerateStats() {
			health = 10 + UnityEngine.Random.value * 20;
		}
    }

	// TODO: Someone figure out how to gray out the stats.
	// In the meantime, itll be super not gray.
	// public class PlayerDataInspector : EditorWindow {

	// }

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
