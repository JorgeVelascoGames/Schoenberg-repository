using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapComponent : MonoBehaviour
{
	protected Map map;

	public void SetUpMap(Map map)
	{
		this.map = map;
	}
}
