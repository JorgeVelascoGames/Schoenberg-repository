using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGameManager : MonoBehaviour
{
	public static DungeonGameManager Instance
	{
		get
		{
			return instance;
		}
	}
	private static DungeonGameManager instance;


	public int level;
	public int baseSeed;

	private int prevRoomPlayerHealth;
	private int prevRoomPlayerCoins;

	private PlayerInput player;

	private void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;

		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		level = 1;
		baseSeed = PlayerPrefs.GetInt("Seed");

		Random.InitState(baseSeed);

		DungeonGenerator.Instance.GenerateDungeon();

		player = FindObjectOfType<PlayerInput>();

		SceneManager.sceneLoaded += OnSceenLoaded;
	}

	public void GoNextLevel()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	void OnSceenLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name != "ProceduralDungeon")
		{
			Destroy(gameObject);
			return;
		}

		player = FindObjectOfType<PlayerInput>();
		level++;
		baseSeed++;

		DungeonGenerator.Instance.GenerateDungeon();
	}
}
