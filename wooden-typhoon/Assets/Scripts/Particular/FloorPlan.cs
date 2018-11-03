using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlan : MonoBehaviour {

	// I shouldn't be writing everything. Maybe take this as inspiration?
	// Also for test behavior, maybe make the numpad transition between rooms like
	//   8 9
	// 4   6
	// 1 2



    // private const int numFloorTypes = 3;
	// static List<GameObject>[] floorTypeToRooms = new List<GameObject>[numFloorTypes];

	// const int floorSize = 10; // Diameter?
	// public int[,] roomLayout = new int[floorSize, floorSize];
	// public GameObject[,] roomInstances = new GameObject[floorSize, floorSize];

	// int floorType = 1; // 0 is hub, 1 for each floor type or something
	// int floorNumber = 1;

	// Use this for initialization
	void Start() {
		DontDestroyOnLoad(this);

		// for (int x = 0; x < floorSize; x++) {
		// 	for (int y = 0; y < floorSize; y++) {
		// 		roomLayout[x,y] = (int)(UnityEngine.Random.value * floorTypeToRooms[floorType].Count);
		// 	}
		// }
	}
	
    // GameObject getRoom(int x, int y) {
		// if (roomInstances[x, y] == null) {
		// 	if (roomLayout[x,y] != -1) {
		// 		GameObject room = floorTypeToRooms[floorType][roomLayout[x,y]];

		// 		roomInstances[x, y] = Instantiate(room, Vector3.zero, Quaternion.identity);
		// 	}
		// }
		// return roomInstances[x, y];
	// }

	// Update is called once per frame
	void Update () {
		
	}
}
