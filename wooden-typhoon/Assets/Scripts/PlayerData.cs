using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	// TODO: Someone figure out how to gray out the stats.
	// In the meantime, itll be super not gray.
	// public class PlayerDataInspector : EditorWindow {

	// }

	public bool generateOnPlay = true;

	public float base_health;
	public float base_attack;

	void Start () {
        // Destroy me on Title Screen
        UnityEngine.Object.DontDestroyOnLoad(this);

		if (generateOnPlay)
		{
			generateBaseStats();
		}
	}

    private void generateBaseStats()
    {
        // throw new NotImplementedException();
		base_health = 10 + UnityEngine.Random.value * 20;
    }
}
