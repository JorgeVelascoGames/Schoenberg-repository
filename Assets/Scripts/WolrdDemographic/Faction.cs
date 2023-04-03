using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using VelascoGames.Utilities;

[System.Serializable]
public class Faction : GameEntity
{
	public Faction(World world)
	{
		this.world = world;

		name = NameGeneratorManager.GetName(this);

		race = Utilities.GetRandomEnumValue<CharacterRace>();

		GenerateCharacters();
	}

	private string name;
	[ShowInInspector]
	public string FactionName => name;	

	private CharacterRace race;
	[ShowInInspector]
	public CharacterRace Race => race;

	//CHARACTERS
	private Character warlod;
	[ShowInInspector]
	public Character Warlod => warlod;

	private Character captain;
	[ShowInInspector]
	public Character Captain => captain;

	private List<Character> knights = new List<Character>();
	[ShowInInspector]
	public List<Character> Knights => knights;

	private List<Character> soldiers = new List<Character>();
	[ShowInInspector]
	public List<Character> Soldiers => soldiers;

	private List<Character> factionMembers = new List<Character>();
	[ShowInInspector]
	public List<Character> FactionMembers => factionMembers;


	private void GenerateCharacters()
	{
		warlod = new Character(race, this, FactionRanges.Warlord);
		factionMembers.Add(warlod);
		captain = new Character(race, this, FactionRanges.Captain);
		factionMembers.Add(captain);

		for (int i = 0; i < GameConfiguration.knightsPerFaction; i++)
		{
			Character newKnight = new Character(race, this, FactionRanges.Knight);
			knights.Add(newKnight);
			factionMembers.Add(newKnight);
		}

		for (int i = 0; i < GameConfiguration.soldiersPerFaction; i++)
		{
			Character newSoldier = new Character(race, this, FactionRanges.Soldier);
			soldiers.Add(newSoldier);
			factionMembers.Add(newSoldier);
		}
	}
}
