using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private GridCell[,] grid;
	private List<GridCell> gridList = new List<GridCell>();
	public List<GridCell> GridList
	{
		get { return gridList; }
	}

	private int width;
	public int Width
	{
		get
		{
			return width;
		}
	}
	private int height;
	public int Height
	{
		get
		{
			return width;
		}
	}

	public GameObject testGridPrefab;

	public void SetUpGrid(int width, int height)
	{
		this.width = width;
		this.height = height;
		grid = new GridCell[width, height];
	}

	public void SetUpDungeonGrid(int width, int height, BiomePreset biom, Vector3 offset)
	{
		this.width = width;
		this.height = height;
		grid = new GridCell[width, height];

		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				GridCell cell = new GridCell(new Vector3(x, y, 0), biom, this, offset);
				grid[x, y] = cell;
				gridList.Add(cell);

				//Instantiate(testGridPrefab, grid[x, y].GridPosition, Quaternion.identity);
			}
		}
	}

	public void AddGridElement(GridCell cell)
	{
		grid[cell.X, cell.Y] = cell;
		gridList.Add(cell);
	}

	public GridCell GetGridByVector(Vector3 pos)
	{
		GridCell cell = grid[(int)pos.x, (int)pos.y];

		return cell;
	}

	public GridCell GetGridByGridPosition(int x, int y)
	{
		GridCell cell = grid[x, y];

		return cell;
	}

	public GridCell GetRandomEmptyCell()
	{
		List<GridCell> tempList = new List<GridCell>();

		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				tempList.Add(grid[x, y]);
			}
		}

		VelascoGames.Utilities.Utilities.Shuffle<GridCell>(tempList);

		return tempList[0];

	}

}
