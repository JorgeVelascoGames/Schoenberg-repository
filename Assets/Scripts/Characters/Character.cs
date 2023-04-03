using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : GameEntity
{
	public Character(CharacterRace race, Faction faction, FactionRanges range)
	{
		characterRace = race;
		this.faction = faction;
		world = faction.World;
		this.range = range;

		switch (world)
		{
			case World.world1:

				switch (this.range)
				{
					case FactionRanges.Soldier:
						level = Random.Range(1, 3);
						break;
					case FactionRanges.Knight:
						level = Random.Range(4, 6);
						break;
					case FactionRanges.Captain:
						level = Random.Range(6, 9);
						break;
					case FactionRanges.Warlord:
						level = 15;
						break;
				}
				
				break;

			case World.world2:

				switch (this.range)
				{
					case FactionRanges.Soldier:
						level = Random.Range(11, 13);
						break;
					case FactionRanges.Knight:
						level = Random.Range(14, 16);
						break;
					case FactionRanges.Captain:
						level = Random.Range(16, 19);
						break;
					case FactionRanges.Warlord:
						level = 25;
						break;
				}

				break;

			case World.world3:

				switch (this.range)
				{
					case FactionRanges.Soldier:
						level = Random.Range(21, 23);
						break;
					case FactionRanges.Knight:
						level = Random.Range(24, 26);
						break;
					case FactionRanges.Captain:
						level = Random.Range(26, 29);
						break;
					case FactionRanges.Warlord:
						level = 35;
						break;
				}

				break;

			case World.world4:

				switch (this.range)
				{
					case FactionRanges.Soldier:
						level = Random.Range(31, 33);
						break;
					case FactionRanges.Knight:
						level = Random.Range(34, 36);
						break;
					case FactionRanges.Captain:
						level = Random.Range(36, 39);
						break;
					case FactionRanges.Warlord:
						level = 45;
						break;
				}

				break;

			case World.world5:

				switch (this.range)
				{
					case FactionRanges.Soldier:
						level = Random.Range(41, 43);
						break;
					case FactionRanges.Knight:
						level = Random.Range(44, 46);
						break;
					case FactionRanges.Captain:
						level = Random.Range(46, 49);
						break;
					case FactionRanges.Warlord:
						level = 55;
						break;
				}

				break;

			case World.world6:

				switch (this.range)
				{
					case FactionRanges.Soldier:
						level = Random.Range(51, 53);
						break;
					case FactionRanges.Knight:
						level = Random.Range(54, 56);
						break;
					case FactionRanges.Captain:
						level = Random.Range(56, 59);
						break;
					case FactionRanges.Warlord:
						level = 65;
						break;
				}

				break;
		}

		inventory = new Inventory();

		world = faction.World;

		name = NameGeneratorManager.GetName(this);
	}


	private string name;
	[ShowInInspector]
	public string Name => name;


	private int level;
	public int Level => level;


	private CharacterRace characterRace;
	[ShowInInspector]
	public CharacterRace Race => characterRace;


	private Faction faction;	
	public Faction CharacterFaction => faction;
	[ShowInInspector]
	public string factionName => faction.FactionName; 


	private FactionRanges range;
	[ShowInInspector]
	public FactionRanges Range => range;


	private Inventory inventory;
	[ShowInInspector]
	public Inventory Inventory => inventory;
}
