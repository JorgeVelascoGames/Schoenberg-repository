using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
	public static DungeonGenerator Instance
	{
		get
		{
			return instance;
		}
	}
	private static DungeonGenerator instance;

	[SerializeField] private GridSystem dungeonGrid;

	[SerializeField] private int mapWidth = 7;
	[SerializeField] private int mapHeight = 7;
	[SerializeField] private int roomsToGenerate = 12;

	private int roomCount;
	private bool roomsInstantiated;

	private Vector2 firstRoomPos;

	private bool[,] map;

	[TabGroup("References")]
	[SerializeField] private GameObject roomPrefab;

	private List<Room> roomObjects = new List<Room>();


	[BoxGroup("Spawn chances")]
	[Range(0,1)]
	public float enemySpawnChance;
	[BoxGroup("Spawn chances")]
	[Range(0, 1)]
	public float coinSpawnChance;
	[BoxGroup("Spawn chances")]
	[Range(0, 1)]
	public float healthSpawnChance;


	[BoxGroup("Spawn chances")]
	public int maxEnemiesPerRoom;
	[BoxGroup("Spawn chances")]
	public int maxCoinsPerRoom;
	[BoxGroup("Spawn chances")]
	public int maxHealthPerRoom;

	private void Awake()
	{
		instance = this;
	}

	public GameObject RequestDungeon(int widht, int height, int amountOfRooms)
	{

		return null;
	}

	public void GenerateDungeon()
	{
		map = new bool[mapWidth, mapHeight];

		CheckRoom(mapWidth / 2, mapHeight / 2, 0, Vector2.zero, true);

		InstantiateRooms();

		GenerateDungeonGrid();


		FindObjectOfType<PlayerInput>().transform.position = firstRoomPos * 12; //12 is the size of the room
	}

	private void GenerateDungeonGrid()
	{
		int gridWidth = 0;
		int gridHeight = 0;

		Vector3 originPos = new Vector3();

		int minX = 10000000;
		int minY = 10000000;

		List<Transform> bricksList = new List<Transform>();

		foreach (Transform pos in GetComponentsInChildren<Transform>())
		{
			if (!pos.CompareTag("Wall"))
				continue; //If its not a wall...

			if (!pos.gameObject.activeSelf)
				continue; //If its now active doesn't count, so we can walk throught doors

			if (pos.position.x < minX)
				minX = (int)pos.position.x;

			if (pos.position.y < minY)
				minY = (int)pos.position.y;

			if (pos.position.x > gridWidth)
				gridWidth = (int)pos.position.x;

			if (pos.position.y > gridHeight)
				gridHeight = (int)pos.position.y;

			bricksList.Add(pos);
		}

		originPos = new Vector3(minX - 4, minY - 4, 0);

		gridWidth -= (int)originPos.x;
		gridHeight -= (int)originPos.y;


		dungeonGrid.SetUpDungeonGrid(gridWidth + 4, gridHeight + 4, null, originPos);

		foreach(var pos in bricksList)
		{
			dungeonGrid.GetGridByVector(pos.position - originPos).SetObjectInGrid(pos.gameObject);
		}

	}

	void CheckRoom(int x, int y, int remaining, Vector2 generalDirection, bool firstRoom = false)
	{
		if(roomCount >= roomsToGenerate)
		{
			return;
		}

		if( x < 0 || x > mapWidth -1 || y < 0 || y > mapHeight - 1)
		{
			return;
		}

		if(!firstRoom && remaining <= 0)
		{
			return;
		}

		if (map[x, y])
		{
			return;
		}

		if (firstRoom)
		{
			firstRoomPos = new Vector2(x, y);
		}

		roomCount++;

		map[x, y] = true;

		bool north = Random.value > (generalDirection == Vector2.up ? 0.2f : 0.8f);
		bool south = Random.value > (generalDirection == Vector2.down ? 0.2f : 0.8f);
		bool east = Random.value > (generalDirection == Vector2.right ? 0.2f : 0.8f);
		bool west = Random.value > (generalDirection == Vector2.left ? 0.2f : 0.8f);

		int maxRemaining = roomsToGenerate / 4; //The 4 is for the 4 directions

		if(north || firstRoom)
		{
			CheckRoom(x, y + 1, firstRoom ? maxRemaining : remaining - 1, firstRoom ? Vector2.up : generalDirection);
		}

		if (south || firstRoom)
		{
			CheckRoom(x, y - 1, firstRoom ? maxRemaining : remaining - 1, firstRoom ? Vector2.down : generalDirection);
		}

		if (east || firstRoom)
		{
			CheckRoom(x + 1, y, firstRoom ? maxRemaining : remaining - 1, firstRoom ? Vector2.right : generalDirection);
		}

		if (west || firstRoom)
		{
			CheckRoom(x - 1, y, firstRoom ? maxRemaining : remaining - 1, firstRoom ? Vector2.left : generalDirection);
		}

	}

	void InstantiateRooms()
	{
		if (roomsInstantiated)
		{
			return;
		}

		roomsInstantiated = true;

		for(int x = 0; x < mapWidth; x++)
		{
			for(int y = 0; y < mapHeight; y++)
			{
				if (!map[x, y])
				{
					continue;
				}

				GameObject roomObj = Instantiate(roomPrefab, new Vector3(x, y, 0) * 12, Quaternion.identity);
				roomObj.transform.parent = transform;

				Room room = roomObj.GetComponent<Room>();

				if(x < mapWidth -1 && map[x + 1, y])
				{
					//We have a room to the right;
					room.HasEastRoom();
				}
				if (x > 0 && map[x - 1, y])
				{
					//We have a room to the left;
					room.HasWestRoom();
				}
				if (y < mapHeight -1 && map[x, y + 1])
				{
					//We have a room to the north;
					room.HasNorthRoom();
				}
				if (y > 0 && map[x, y - 1])
				{
					//We have a room to the south;
					room.HasSouthRoom();
				}

				if(firstRoomPos != new Vector2(x, y))
				{
					room.GenerateInterior();
				}

				roomObjects.Add(room);
			}
		}

		//CalculateKeyAndExit();
	}

	void CalculateKeyAndExit()
	{
		float maxDist = 0;
		Room a = null;
		Room b = null;

		foreach(Room aRoom in roomObjects)
		{
			foreach(Room bRoom in roomObjects)
			{
				float dist = Vector3.Distance(aRoom.transform.position, bRoom.transform.position);

				if(dist > maxDist)
				{
					maxDist = dist;
					a = aRoom;
					b = bRoom;
				}
			}
		}

		a.SpawnPrefab(a.keyPrefab);
		b.SpawnPrefab(b.exitDoorPrefab);
	}
}
