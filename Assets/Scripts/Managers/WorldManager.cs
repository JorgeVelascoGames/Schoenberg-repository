using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
	[SerializeField] private Map map1, map2, map3, map4, map5, map6;

	private Map activeMap;
	public Map ActiveMap
	{
		get
		{
			return activeMap;
		}
	}

	public void CreateWorld()
	{
		map1.InitMap();
		map2.InitMap();
		map3.InitMap();
		map4.InitMap();
		map5.InitMap();
		map6.InitMap();

		GoToWorld1();
	}

	[Button]
	public void GoToWorld1()
	{
		map1.SetMapActive(true);
		map2.SetMapActive(false);
		map3.SetMapActive(false);
		map4.SetMapActive(false);
		map5.SetMapActive(false);
		map6.SetMapActive(false);

		activeMap = map1;
	}
	[Button]
	public void GoToWorld2()
	{
		map1.SetMapActive(false);
		map2.SetMapActive(true);
		map3.SetMapActive(false);
		map4.SetMapActive(false);
		map5.SetMapActive(false);
		map6.SetMapActive(false);

		activeMap = map2;
	}
	[Button]
	public void GoToWorld3()
	{
		map1.SetMapActive(false);
		map2.SetMapActive(false);
		map3.SetMapActive(true);
		map4.SetMapActive(false);
		map5.SetMapActive(false);
		map6.SetMapActive(false);

		activeMap = map3;
	}
	[Button]
	public void GoToWorld4()
	{
		map1.SetMapActive(false);
		map2.SetMapActive(false);
		map3.SetMapActive(false);
		map4.SetMapActive(true);
		map5.SetMapActive(false);
		map6.SetMapActive(false);

		activeMap = map4;
	}
	[Button]
	public void GoToWorld5()
	{
		map1.SetMapActive(false);
		map2.SetMapActive(false);
		map3.SetMapActive(false);
		map4.SetMapActive(false);
		map5.SetMapActive(true);
		map6.SetMapActive(false);

		activeMap = map5;
	}
	[Button]
	public void GoToWorld6()
	{
		map1.SetMapActive(false);
		map2.SetMapActive(false);
		map3.SetMapActive(false);
		map4.SetMapActive(false);
		map5.SetMapActive(false);
		map6.SetMapActive(true);

		activeMap = map6;
	}

	public GridSystem GetActiveGrid()
	{
		return ActiveMap.MapGrid.LevelGrid;
	}
}
