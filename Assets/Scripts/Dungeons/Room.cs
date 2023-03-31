using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	[TabGroup("Walls")]
	[SerializeField] private GameObject wallNorth;
	[TabGroup("Walls")]
	[SerializeField] private GameObject wallSouth;
	[TabGroup("Walls")]
	[SerializeField] private GameObject wallRight;
	[TabGroup("Walls")]
	[SerializeField] private GameObject wallLeft;


	[TabGroup("Doors")]
	[SerializeField] private GameObject doorNorth;
	[TabGroup("Doors")]
	[SerializeField] private GameObject doorSouth;
	[TabGroup("Doors")]
	[SerializeField] private GameObject doorRight;
	[TabGroup("Doors")]
	[SerializeField] private GameObject doorLeft;

	[TabGroup("Room configuration")]
	[SerializeField] private int insideWidth;
	[TabGroup("Room configuration")]
	[SerializeField] private int insideHeight;

	[TabGroup("References")]
	[SerializeField] private GameObject enemyPrefab;
	[TabGroup("References")]
	[SerializeField] private GameObject coinPrefab;
	[TabGroup("References")]
	[SerializeField] private GameObject healthPrefab;
	[TabGroup("References")]
	public GameObject exitDoorPrefab;
	[TabGroup("References")]
	public GameObject keyPrefab;

	private List<Vector3> usedPositions = new List<Vector3>();

	public void GenerateInterior()
	{
		if(Random.value < DungeonGenerator.Instance.enemySpawnChance)
		{
			SpawnPrefab(enemyPrefab, DungeonGenerator.Instance.maxEnemiesPerRoom + 1);
		}

		if(Random.value < DungeonGenerator.Instance.coinSpawnChance)
		{
			SpawnPrefab(coinPrefab, DungeonGenerator.Instance.maxCoinsPerRoom + 1);
		}

		if (Random.value < DungeonGenerator.Instance.healthSpawnChance)
		{
			SpawnPrefab(healthPrefab, DungeonGenerator.Instance.maxHealthPerRoom + 1);
		}
	}

	public void SpawnPrefab(GameObject prefab, int min = 0, int max = 0)
	{
		int num = 1;

		if(min != 0 || max != 0)
		{
			num = Random.Range(min, max);
		}

		for(int x = 0; x < num; x++)
		{
			GameObject obj = Instantiate(prefab);
			Vector3 pos = transform.position + new Vector3(Random.Range(-insideWidth / 2 + 1, insideWidth / 2 - 1),
				Random.Range(-insideHeight / 2 + 1, insideHeight / 2 - 1), 0);

			while (usedPositions.Contains(pos))
			{
				pos = transform.position + new Vector3(Random.Range(-insideWidth / 2 + 1, insideWidth / 2 - 1),
				Random.Range(-insideHeight / 2 + 1, insideHeight / 2 - 1), 0);
			}

			obj.transform.position = pos;
			usedPositions.Add(pos);

			if(prefab == enemyPrefab)
			{
				//Enemies and elements in room
			}

		}
	}

	public void HasNorthRoom()
	{
		doorNorth.SetActive(true);
		wallNorth.SetActive(false);
	}
	public void HasSouthRoom()
	{
		doorSouth.SetActive(true);
		wallSouth.SetActive(false);
	}
	public void HasEastRoom()
	{
		doorRight.SetActive(true);
		wallRight.SetActive(false);
	}
	public void HasWestRoom()
	{
		doorLeft.SetActive(true);
		wallLeft.SetActive(false);
	}
}
