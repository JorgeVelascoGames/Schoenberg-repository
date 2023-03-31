using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}
	private static GameManager instance;

	[SerializeField] private WorldManager worldManager;
	[SerializeField] private PlayerBrain player;
	public WorldManager WorldManager
	{
		get
		{
			return worldManager;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
	}

	[Button]
	private void SetUpWorld()
	{

		worldManager.CreateWorld();
	}

	[Button]
	private void PlayerReady()
	{
		player.WarpPlayer(worldManager.GetActiveGrid().GetRandomEmptyCell());
	}
}
