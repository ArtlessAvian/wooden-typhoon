using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorplan : MonoBehaviour {

	public class Room {
		int width;
		int height;
		
		void addToFloor(int floor)
		{
			floorRooms[floor].Add(this);
		}
	}

	const int NUM_FLOORS = 1;
	static List<Room>[] floorRooms = new List<Room>[NUM_FLOORS];

	public int floorNum = 1;
	public bool dontGenerate = false;

	void Start () {
		// Generate the Floor somehow
		// IDEAS:
		// Rooms and hallways
			// Put a room near another room, and connect the two.
			// Less Dense, but long hallways are ugly
			// Generating the hallways may be tough?
		// Zelda 1 / Binding of Issac
			// Every room is a rectangle, dimensions a multiple of some constant.
			// Rooms are put in a big easy grid.
			// Low Scope, but boring
		// Add more, if you have any ideas.
	}
	
	// void Update () {
		
	// }
}
