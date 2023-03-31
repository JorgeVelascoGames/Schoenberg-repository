using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NameGeneratorManager
{
	private static FactionNameGenerator factionNameGenerator = new FactionNameGenerator();
	private static WeaponNameGenerator weaponNameGenerator = new WeaponNameGenerator();
	private static CharacterNameGenerator characterNameGenerator = new CharacterNameGenerator();

	public static string GetName(GameEntity entity)
	{
		string name = "";

		switch (entity)
		{
			case Weapon weapon:
				name = weaponNameGenerator.GetWeaponName(weapon);
				break;
			case Faction faction:
				name = factionNameGenerator.GetFactionName();
				break;
			case Character character:
				name = characterNameGenerator.GetCharacterName(character.Race);
				break;
		}

		return name.ToUpper();
	}
}
