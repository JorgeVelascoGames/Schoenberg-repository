using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MapComponent
{
	private List<Weapon> weaponsToLoot = new List<Weapon>();
	[ShowInInspector]
	public List<Weapon> Weapons => weaponsToLoot;


	public void GenerateWeapons()
	{

	}
}
