using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorplan : MonoBehaviour {

	public class RoomSetpiece {
		int width;
		int height;
		
		void AddToFloor(int floor)
		{
			floorSetpieces[floor].Add(this);
		}
	}

	public class Room {
		
		public bool cleared = false;
		public List<GameObject> enemies = new List<GameObject>();
		
		public readonly RoomSetpiece SETPIECE;

		public Room(RoomSetpiece setpiece) {
			this.SETPIECE = setpiece;
		}
		
		public void AddEnemy(GameObject enemy) {
			enemies.Add(enemy);
			Hurtbox enemyHurtbox = enemy.GetComponent<Hurtbox>();
			enemyHurtbox.onDie += enemyDieCallback;
		}

		public void enemyDieCallback(GameObject enemy) {
			enemies.Remove(enemy);
			if (enemies.Count == 0) {
				cleared = true;
			}
		}
	}

	const int NUM_FLOORS = 1;

	public int floorNum = 1;
	public bool dontGenerate = false;

	private List<Room> rooms = new List<Room>();

	private static List<RoomSetpiece>[] floorSetpieces = new List<RoomSetpiece>[NUM_FLOORS];

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
