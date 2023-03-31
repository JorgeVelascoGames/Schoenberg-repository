using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Biome preset", menuName = "New Biome Preset")]
public class BiomePreset : ScriptableObject
{
	public Color debugColor;
	public Tile[] tiles;

	public float minHeight;
	public float minMoisture;
	public float minHeat;

	public bool MatchCondition(float height, float moisture, float heat)
	{
		return height >= minHeight && moisture >= minMoisture && heat >= minHeat;
	}

	public Tile GetTile()
	{
		int i = Random.Range(0, tiles.Length - 1);

		return tiles[i];
	}
}
