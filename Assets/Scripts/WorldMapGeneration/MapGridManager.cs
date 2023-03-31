using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGridManager : MapComponent
{
	private List<GridCell> suitedCells = new List<GridCell>();
	public List<GridCell> SuitedCellsList
	{
		get
		{
			return suitedCells;
		}
	}


	[BoxGroup("References")]
	[SerializeField] private GridSystem levelGrid;
	public GridSystem LevelGrid
	{
		get
		{
			return levelGrid;
		}
	}


	private void Awake()
	{
		//GridCell.OnFreeCell += OnFreedCell;
		//GridCell.OnOccupiedCell += OnOccupiedCell;   We dont need this for now
	}

	public void InitializeGrid()
	{
		levelGrid.SetUpGrid(map.Width, map.Height);
	}


	private List<GridCell> SuitedCellList()
	{
		List<GridCell> tempList = new List<GridCell>();

		foreach(GridCell cell in levelGrid.GridList)
		{
			if (TestSuitedCell(cell))
			{
				if (!suitedCells.Contains(cell))
					tempList.Add(cell);
			}
		}

		return tempList;
	}

	/// <summary>
	/// This returns true if a cell is surrounded only by empty cells of the same biom
	/// </summary>
	/// <param name="cell"></param>
	/// <returns></returns>
	public bool TestSuitedCell(GridCell cell)
	{
		if (cell.IsOccupied || cell.hasPlayer)
			return false;

		if (!cell.BiomContinueNorth())
			return false;
		if (!cell.BiomContinueSouth())
			return false;
		if (!cell.BiomContinueEast())
			return false;
		if (!cell.BiomContinueWest())
			return false;

		if (!cell.HasOpenNorth())
			return false;
		if (!cell.HasOpenSouth())
			return false;
		if (!cell.HasOpenEast())
			return false;
		if (!cell.HasOpenWest())
			return false;


		return true;
	}

	private void OnFreedCell(GridCell cell)
	{
		if (cell.gridSystem == levelGrid && !cell.IsOccupied)
		{
			suitedCells.Add(cell);
		}
	}
	private void OnOccupiedCell(GridCell cell)
	{
		if (cell.gridSystem == levelGrid && cell.IsOccupied)
		{
			suitedCells.Remove(cell);
		}
	}
}
