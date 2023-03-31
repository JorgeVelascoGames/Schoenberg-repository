using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerBrain : MonoBehaviour
{
	[TabGroup("References")]
	[SerializeField] private PlayerInput playerInput;
	public PlayerInput PlayerInput
	{
		get
		{
			return playerInput;
		}
	}

	[ShowInInspector]
	public GridCell CurrentCell { get; private set; }
	public GridSystem CurrentLevelGrid
	{
		get
		{
			return CurrentCell.gridSystem;
		}
	}


	private void Awake()
	{
		foreach(var element in GetComponentsInChildren<PlayerBrainElement>())
		{
			element.SetUpBrain(this);
		}

		playerInput.OnMovement += UpdateCell;
	}

	public void UpdateCell()
	{
		if(CurrentCell != null)
		{
			CurrentCell.MoveOutCell();
		}

		CurrentCell = GameManager.Instance.WorldManager.GetActiveGrid().GetGridByVector(transform.position);
	}

	public void UpdateCell(GridCell cell)
	{
		if (CurrentCell != null)
		{
			CurrentCell.MoveOutCell();
		}

		CurrentCell = cell;
	}

	public void WarpPlayer(GridCell cell)
	{
		transform.position = new Vector3(cell.X, cell.Y, 0);

		UpdateCell();
	}
}
