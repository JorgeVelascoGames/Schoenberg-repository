using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNameGenerator
{
	//Weapon types
	private SwordName swordName = new SwordName();
	private SpearName spearName = new SpearName();
	private MazeName mazeName = new MazeName();
	private StaffName staffName = new StaffName();
	private DaggerName daggerName = new DaggerName();
	private BowName bowName = new BowName();

	public string GetWeaponName(Weapon weapon)
	{
		string name = "";

		switch (weapon)
		{
			case Sword sword:
				name = swordName.GetWeaponName(sword.WeaponQuality);
				break;
			case Spear spear:
				name = spearName.GetWeaponName(spear.WeaponQuality);
				break;
			case Maze maze:
				name = mazeName.GetWeaponName(maze.WeaponQuality);
				break;
			case Staff staff:
				name = staffName.GetWeaponName(staff.WeaponQuality);
				break;
			case Dagger dagger:
				name = daggerName.GetWeaponName(dagger.WeaponQuality);
				break;
			case Bow bow:
				name = bowName.GetWeaponName(bow.WeaponQuality);
				break;
		}

		return name.ToUpper();
	}

	private abstract class WeaponName
	{
		protected string[] weaponTypeNames;

		protected string[] firstPlaceCrudeAdjetives = new string[] {"Rusty", "Weathered", "Worn", "aged", "tarnished", "pitted", "corroed", "blunted",
		"bent", "brittle", "cracked", "faded", "rusted", "stained"," tattered", "timeworn", "whitered", "withered", "scratched", "wooden"};
		protected string[] firstPlaceCommonAdjetives = new string[] {
			"Shining",
			"Gleaming",
			"Glinting",
			"Sleek",
			"Pristine",
			"Polished",
			"Sharp",
			"Reliable",
			"Balanced",
			"Solid",
			"Sturdy",
			"Standard",
			"Functional",
			"Ornate"
		};
		protected string[] firstPlaceRareAdjetives = new string[]
		{
			"Fine",
			"Durable",
			"Stalwart",
			"Dependable",
			"Resilient",
			"Robust",
			"Trusty",
			"Solid",
			"Reliable",
			"Standard",
			"Functional",
			"Balanced",
			"Plain",
			"Practical",
			"Serviceable",
			"Simple",
			"Basic",
			"Dependable",
			"Regal",
			"Noble",
			"Prestigious"
		};
		protected string[] firstPlaceEpicAdjetives = new string[]
		{
			"Mythical",
			"Divine",
			"Exquisite",
			"Masterful",
			"Ethereal",
			"Enchanted",
			"Peerless",
			"Radiant",
			"Immaculate",
			"Flawless",
			"Infernal",
			"Celestial",
			"Supreme",
			"Peerless",
			"Majestic",
			"Grand",
		};

		private string[] legendaryItemFirstPart = new string[]
		{
			"Flaming",
			"Lonely",
			"Holy",
			"Tormented",
			"Mystic",
			"Endless",
			"Scarred",
			"Damned",
			"Immortal",
			"Dark",
			"Eternal",
			"Blazing",
			"Forgotten",
			"Infinite",
			"Burning",
			"Fallen",
			"Legendary",
			"Divine",
			"Merciless",
			"Celestial",
			"Frozen",
			"Broken",
			"Bleeding"
		};
		private string[] legendaryItemSecondPart = new string[]
		{
			"Fate",
			"Saga",
			"Tragedy",
			"Glory",
			"Fury",
			"Destiny",
			"Star",
			"War",
			"Abyss",
			"Waterfall",
			"Illusion",
			"Lake",
			"Victory",
			"Divinity",
			"Vision",
			"Prophecy",
			"Blood",
			"Eternity"
		};
		private string[] legendaryItemThirdPart = new string[]
		{
			"Majesties",
			"Demonknights",
			"Slaves",
			"Hearts",
			"Hellgods",
			"Wizards",
			"Warriors",
			"Ghosts",
			"Unicorns",
			"Angels",
			"Lords",
			"Titans",
			"Heroes",
			"Dragons",
			"Gods",
			"Demons",
			"Warlords",
			"Souls",
			"Men",
			"Beasts",
			"Sons",
			"Kings"
		};

		public string GetWeaponName(WeaponQuality quality)
		{
			string name = "";

			switch (quality)
			{
				case WeaponQuality.Crude:
					name = GetCrudeWeaponName();
					break;
				case WeaponQuality.Common:
					name = GetCommonWeaponName();
					break;
				case WeaponQuality.Rare:
					name = GetRareWeaponName();
					break;
				case WeaponQuality.Epic:
					name = GetEpicWeaponName();
					break;
				case WeaponQuality.Legendary:
					name = GetLegendaryWeaponName();
					break;
			}

			return name.ToUpper();
		}

		protected string GetCrudeWeaponName()
		{
			string name = "";

			name = firstPlaceCrudeAdjetives[Random.Range(0, firstPlaceCrudeAdjetives.Length)] + " " + weaponTypeNames[Random.Range(0, weaponTypeNames.Length)];

			return name;
		}

		protected string GetCommonWeaponName()
		{
			string name = "";

			name = firstPlaceCommonAdjetives[Random.Range(0, firstPlaceCommonAdjetives.Length)] + " " + weaponTypeNames[Random.Range(0, weaponTypeNames.Length)];

			return name;
		}

		protected string GetRareWeaponName()
		{
			string name = "";

			name = firstPlaceRareAdjetives[Random.Range(0, firstPlaceRareAdjetives.Length)] + " " + weaponTypeNames[Random.Range(0, weaponTypeNames.Length)];

			return name;
		}

		protected string GetEpicWeaponName()
		{
			string name = "";

			name = firstPlaceEpicAdjetives[Random.Range(0, firstPlaceEpicAdjetives.Length)] + " " + weaponTypeNames[Random.Range(0, weaponTypeNames.Length)];

			return name;
		}

		private string GetLegendaryWeaponName()
		{
			string name = "";

			string first = legendaryItemFirstPart[Random.Range(0, legendaryItemFirstPart.Length)];
			string second = legendaryItemSecondPart[Random.Range(0, legendaryItemSecondPart.Length)];
			string third = legendaryItemThirdPart[Random.Range(0, legendaryItemThirdPart.Length)];

			name = first + " " + second + " of " + third;

			return name;
		}
	}

	private class SwordName : WeaponName
	{
		public SwordName()
		{
			weaponTypeNames = swordName;
		}


		private string[] swordName = new string[] {"Gladius", "Falchion", "Cutlass", "Sabre", "Longsword", "Claymore", "Scimitar", "Rapier",
		"Estoc", "Jian", "Kris", "Machete", "Zweihander", "Shamshir", "Messer", "Shamshir", "Broadsword"};		
	}
	private class SpearName : WeaponName
	{
		public SpearName()
		{
			weaponTypeNames = spearName;
		}


		string[] spearName = new string[] { "Spear", "Halberd", "Pike", "Trident", "Glaive", "Javelin", 
			"Lance", "Naginata", "Partisan", "Voulge", "Bardiche", "Fauchard", "Ranseur", "Guisarme", 
			"Lochaber Axe", "Billhook", "Brandistock", "Winged spear", "Ash spear", 
			"Hunting spear", "Military fork", "Yari", "Kunko-yari", "Sibat", "Kiping" };
	}
	private class MazeName : WeaponName
	{
		public MazeName()
		{
			weaponTypeNames = mazeName;
		}

		string[] mazeName = { "Warhammer", "Mace", "Morning star", "Flail", "Bludgeon", 
			"Cudgel", "Bec de corbin", "Lucerne", "Footman's flail", "Greatclub", "Sledgehammer", "Crowbill"};

	}
	private class StaffName : WeaponName
	{
		public StaffName()
		{
			weaponTypeNames = stickNames;

		}

		string[] stickNames = { "Staff", "Club", "Baton", "Truncheon", "Bludgeon", 
			"Cane", "Polearm", "Quarterstaff", "Bo staff", "Shillelagh", "Wand", "Rod", 
			"Pikestaff", "Lathi", "Jo staff", "Tanbo" };

	}
	private class DaggerName : WeaponName
	{
		public DaggerName()
		{
			weaponTypeNames = daggerNames;
		}

		string[] daggerNames = { "knife", "dirk", "stiletto", "shiv", "blade", "dagger", 
			"jambiya", "kriss", "skean", "glaive" };

	}
	private class BowName : WeaponName
	{
		public BowName()
		{
			weaponTypeNames = bowNames;
		}

		string[] bowNames = { "Longbow", "Recurve bow", "Compound bow", "Crossbow", 
			"Arbalest", "Repeating crossbow", "Yumi", "Shortbow", "Self bow", 
			"Composite bow", "Sling", "Hand crossbow", "Hunting bow", "War bow", "English longbow", "Reflex bow" };

	}
}
