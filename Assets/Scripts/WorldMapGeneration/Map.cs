using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public enum MapDisplay
{
	Height,
	Moisture,
	Heat,
	Biome,
}

[RequireComponent(typeof(MapGridManager))]
[RequireComponent(typeof(MapElementsGeneration))]
public class Map : MonoBehaviour
{
	[BoxGroup("Map configuration")]
	[SerializeField] private int width;
	public int Width
	{
		get
		{
			return width;
		}
	}
	[BoxGroup("Map configuration")]
	[SerializeField] private int height;
	public int Height
	{
		get
		{
			return height;
		}
	}
	[BoxGroup("Map configuration")]
	[SerializeField] private float scale;
	[BoxGroup("Map configuration")]
	[SerializeField] private Vector2 offset;

	[BoxGroup("Height Map")]
	public Wave[] heightWaves;
	[BoxGroup("Height Map")]
	public float[,] heightMap;
	[BoxGroup("Height Map")]
	public Gradient heightDebugColors;

	[BoxGroup("Moisture Map")]
	public Wave[] moistureWaves;
	[BoxGroup("Moisture Map")]
	public float[,] moistureMap;
	[BoxGroup("Moisture Map")]
	public Gradient moistureDebugColors;

	[BoxGroup("Heat Map")]
	public Wave[] heatWaves;
	[BoxGroup("Heat Map")]
	public float[,] heatMap;
	[BoxGroup("Heat Map")]
	public Gradient heatDebugColors;


	[BoxGroup("References")]
	[SerializeField] private RawImage debugImage;
	[BoxGroup("References")]
	[SerializeField] private MapDisplay displayTipe;
	[BoxGroup("References")]
	[SerializeField] private BiomePreset[] bioms;
	[BoxGroup("References")]
	[SerializeField] private BiomePreset water;
	[BoxGroup("References")]
	[SerializeField] private Tilemap tilemap;
	[BoxGroup("References")]
	[SerializeField] private Transform mapElementsContainer;

	private MapGridManager mapGridManager;
	public MapGridManager MapGrid
	{
		get
		{
			return mapGridManager;
		}
	}

	private void Awake()
	{
		foreach(MapComponent mComp in GetComponents<MapComponent>())
		{
			mComp.SetUpMap(this);
		}

		mapGridManager = GetComponent<MapGridManager>();
	}

	public void InitMap()
	{
		mapGridManager.InitializeGrid();
		GenerateMap();
	}

	public void SetMapActive(bool state)
	{
		mapElementsContainer.gameObject.SetActive(state);
	}

	void GenerateMap()
	{
		RandomizeWaves();


		heightMap = NoiseGenerator.Generate(width, height, scale, offset, heightWaves);

		moistureMap = NoiseGenerator.Generate(width, height, scale, offset, moistureWaves);

		heatMap = NoiseGenerator.Generate(width, height, scale, offset, heatWaves);

		Color[] pixels = new Color[width * height];
		int i = 0;

		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				switch (displayTipe)
				{
					case MapDisplay.Height:

						pixels[i] = heightDebugColors.Evaluate(heightMap[x, y]);

						break;
					case MapDisplay.Moisture:

						pixels[i] = moistureDebugColors.Evaluate(moistureMap[x, y]);

						break;
					case MapDisplay.Heat:

						pixels[i] = heatDebugColors.Evaluate(heatMap[x, y]);

						break;
					case MapDisplay.Biome:

						BiomePreset biom = GetBiom(heightMap[x, y], moistureMap[x, y], heatMap[x, y]);

						pixels[i] = biom.debugColor;

						if (Application.isPlaying)
						{
							Tile tile = biom.GetTile();

							GridCell gridCell = new GridCell(new Vector3(x, y, 0), biom, mapGridManager.LevelGrid);

							mapGridManager.LevelGrid.AddGridElement(gridCell);

							tilemap.SetTile(new Vector3Int(x, y, 0), tile);
						}
						break;
				}
				i++;
			}
		}

		Texture2D tex = new Texture2D(width, height);
		tex.SetPixels(pixels);
		tex.filterMode = FilterMode.Point;
		tex.Apply();

		debugImage.texture = tex;
	}

	private void RandomizeWaves()
	{
		foreach(var wave in heatWaves)
		{
			wave.seed = UnityEngine.Random.Range(2000, 3000);
		}
		foreach (var wave in heightWaves)
		{
			wave.seed = UnityEngine.Random.Range(2000, 3000);
		}
		foreach (var wave in moistureWaves)
		{
			wave.seed = UnityEngine.Random.Range(2000, 3000);
		}
	}

	private BiomePreset GetBiom(float height, float moisture, float heat)
	{
		BiomePreset biomeToReturn = null;

		List<BiomePreset> tempBiomes = new List<BiomePreset>();

		foreach(var biome in bioms)
		{
			if (biome.MatchCondition(height, moisture, heat))
			{
				tempBiomes.Add(biome);
			}
		}

		float curValue = 0.0f;

		foreach(BiomePreset biome in tempBiomes)
		{
			float diffValue = (height - biome.minHeight) + (moisture - biome.minMoisture) + (heat - biome.minHeat);

			if(biomeToReturn == null)
			{
				biomeToReturn = biome;
				curValue = diffValue;
			}
			else if(diffValue < curValue)
			{
				biomeToReturn = biome;
				curValue = diffValue;
			}
		}

		if(biomeToReturn == null)
		{
			biomeToReturn = water;
		}

		return biomeToReturn;
	}
}
