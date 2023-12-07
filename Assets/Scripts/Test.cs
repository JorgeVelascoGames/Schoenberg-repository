using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{

	[Button]
	public void GenerateCharacterName(CharacterRace race)
	{
		Debug.Log(new CharacterNameGenerator().GetCharacterName(race));
	}

	[Button]
	public void GenerateFactionName()
	{
		Debug.Log(new FactionNameGenerator().GetFactionName());
	}
}
