using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionManager : MapComponent
{
	[ShowInInspector]
	private Faction factionOne;
	[ShowInInspector]
	private Faction factionTwo;
	[ShowInInspector]
	private Faction factionThree;


	[Button]
	public void CreateFactions()
	{
		factionOne = new Faction(map.World);
		factionTwo = new Faction(map.World);
		factionThree = new Faction(map.World);
	}
}
