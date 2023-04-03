using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity
{
	protected World world;
	[ShowInInspector]
	public World World => world;
}
