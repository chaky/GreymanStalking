using UnityEngine;
using System.Collections;

public class ProceduralRoom : MonoBehaviour {

	//Enums
	public enum TileType {Floor, Ceil, Door, Wall, Asset}
	public enum RoomType {Start, Easy, Medium, Difficult, Trap, Treasure, Boss, End}


	//world info
	public const int worldWidth = 10;
	public const int worldHeight = 10;
	public const int roomWidth = 40;
	public const int roomHeight = 40;
	private Room[, ] rooms = new Room[worldWidth, worldHeight];

	//actual room
	private Room room;

	//tileset
	public Tile[] tiles;


	[System.Serializable]
	public class Tile {
		/** Prefab to use */
		public GameObject prefab;
		/** Tipe of Tile */
		public TileType type;

		public bool breakable = true;
		public int health = 100;
		public Transform transform;
	}
	
	public class Room {
		public RoomType type;
		private int x;
		private int y;
		public int X {
			get {
				return x;
			}
			set {
				if ((value > 0) && (value < worldWidth)){
					x = value;
				}
			}
		}
		public int Y {
			get {
				return y;
			}
			set {
				if ((value > 0) && (value < worldHeight)){
					y = value;
				}
			}
		}
	}

	/** Use this for initialization
	 */
	void Start () {
		InitializeWorld();
	}
	
	/** Update is called once per frame
	*/
	void Update () {
	
	}

	/** Create Procedural World
	 */
	void InitializeWorld() {
		//TODO: One Start Room, One End Room, conditions
		for(int i = 0; i < worldWidth; i++) {
			for(int j = 0; j < worldHeight; j++) {

				rooms[i, j] = new Room();
			}
		}
		//set starting room
		room = new Room();
		InitializeRoom(room, RoomType.Start);
		//set other rooms

		//tell gamestate to start
		GameObject go = GameObject.Find ("Unit");
		go.GetComponent<AIPather>().StartPath();
	}

	/** Create Procedural Rooms
	 */
	void InitializeRoom(Room pRoom, RoomType pRoomType) {
		pRoom.type = pRoomType;
		//TODO:
		//floor
		for(int i = 0; i < roomWidth; i++) {
			for(int j = 0; j < roomHeight; j++) {
				GameObject ob = GameObject.Instantiate ( tiles[0].prefab, new Vector3(i, -0.5f, j), Quaternion.identity ) as GameObject;
			}
		}
	}
}
