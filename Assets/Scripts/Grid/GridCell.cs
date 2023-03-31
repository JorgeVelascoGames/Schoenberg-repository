using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridCell
{
	public static Action<GridCell> OnOccupiedCell;
	public static Action<GridCell> OnFreeCell;

	public GridCell(Vector3 position, BiomePreset biom, GridSystem gridSystem)
	{
		this.biom = biom;
		gridPosition = position;
		this.gridSystem = gridSystem;
		occupiedGrid = false;

		x = (int)position.x;
		y = (int)position.y;
	}
	public GridCell(Vector3 position, BiomePreset biom, GridSystem gridSystem, Vector3 offset)
	{
		this.biom = biom;
		gridPosition = position + offset;
		this.gridSystem = gridSystem;
		occupiedGrid = false;

		x = (int)position.x + (int)offset.x;
		y = (int)position.y + (int)offset.y;
	}
	public GridCell(int x, int y , BiomePreset biom, GridSystem gridSystem)
	{
		this.biom = biom;
		gridPosition = new Vector3(x, y, 0);
		this.gridSystem = gridSystem;
		occupiedGrid = false;

		this.x = x;
		this.y = y;
	}

	[ShowInInspector]
	private int x;
	public int X => x;
	[ShowInInspector] 
	private int y;
	public int Y => y;


	private Vector3 gridPosition = new Vector3();
	public Vector3 GridPosition => gridPosition;

	public BiomePreset biom { get; private set; }

	public GridSystem gridSystem { get; private set; }

	private bool _occupiedGrid;
	private bool occupiedGrid 
	{
		get
		{
			return _occupiedGrid;
		}
		
		set
		{
			if (value)
			{
				if(OnOccupiedCell != null)
				{
					if(OnOccupiedCell != null)
						OnOccupiedCell(this);
				}
				else
				{
					if(OnFreeCell != null)
						OnFreeCell(this);
					
				}

				_occupiedGrid = value;
			}
			else
			{
				_occupiedGrid = value;
			}
		}
	}
	public bool IsOccupied
	{
		get
		{
			return occupiedGrid;
		}
	}
	public bool hasPlayer { get; private set; }

	public GameObject objectInGrid { get; private set; }


	public void SetObjectInGrid(GameObject obj)
	{
		if (occupiedGrid)
		{
			return;
		}

		objectInGrid = obj;

		occupiedGrid = true;
	}

	public bool TryMoveToCell()
	{
		if (!occupiedGrid)
		{
			hasPlayer = true;
			occupiedGrid = true;
			Debug.Log("Yes you can move");
			return true;
		}

		if (objectInGrid == null)
		{
			Debug.Log(occupiedGrid);
			return false;
		}

		if(objectInGrid.TryGetComponent<IPlayerInteract>(out IPlayerInteract interact))
		{
			interact.PlayerInteract();
		}

		Debug.Log("No you cant move because there is an object");
		return false;
	}

	public void MoveOutCell()
	{
		hasPlayer = false;
		occupiedGrid = false;
	}


	#region Check adjacent cells

	public bool HasOpenNorth()
	{
		if(gridSystem.Height <= y) //We are in the edge
		{
			return false;
		}

		if(gridSystem.GetGridByGridPosition(x, y + 1).occupiedGrid)
		{
			return false;
		}

		return true;
	}

	public bool HasOpenSouth()
	{
		if(y == 0) //We are in the edge
		{
			return false;
		}

		if (gridSystem.GetGridByGridPosition(x, y - 1).occupiedGrid)
		{
			return false;
		}
		Debug.Log("There is no south");

		return true;

	}

	public bool HasOpenEast()
	{
		if(gridSystem.Width <= x) //We are in the edge
		{
			return false;
		}

		if (gridSystem.GetGridByGridPosition(x + 1, y).occupiedGrid)
		{
			return false;
		}
		Debug.Log("There is no east");

		return true;

	}

	public bool HasOpenWest()
	{
		if(x == 0) //We are in the edge
		{
			return false;
		}

		if (gridSystem.GetGridByGridPosition(x - 1, y).occupiedGrid)
		{
			return false;
		}
		Debug.Log("There is no west");

		return true;

	}

	public bool BiomContinueNorth()
	{

		if (gridSystem.Height <= y) //We are in the edge
		{
			return false;
		}

		if (gridSystem.GetGridByGridPosition(x, y + 1).biom != biom)
		{
			return false;
		}

		return true;
	}

	public bool BiomContinueSouth()
	{
		if (y == 0) //We are in the edge
		{
			return false;
		}

		if (gridSystem.GetGridByGridPosition(x, y - 1).biom != biom)
		{
			return false;
		}
		Debug.Log("There is no south");

		return true;
	}

	public bool BiomContinueEast()
	{
		if (gridSystem.Width <= x) //We are in the edge
		{
			return false;
		}

		if (gridSystem.GetGridByGridPosition(x + 1, y).biom != biom)
		{
			return false;
		}
		Debug.Log("There is no east");

		return true;

	}

	public bool BiomContinueWest()
	{
		if (x == 0) //We are in the edge
		{
			return false;
		}

		if (gridSystem.GetGridByGridPosition(x - 1, y).biom != biom)
		{
			return false;
		}
		Debug.Log("There is no west");

		return true;
	}

	#endregion
}
