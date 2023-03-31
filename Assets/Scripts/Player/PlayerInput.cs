using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInput : PlayerBrainElement
{
	public Action OnMovement;

	[SerializeField] private float speed;

	private float resetMoveTime;
	[SerializeField]
	private bool canMoveUp, canMoveDown, canMoveLeft, canMoveRight;

	
	private bool WaitingToMove()
	{
		if(Time.time - resetMoveTime > speed)
		{
			resetMoveTime = Time.time;
			return false;
		}

		return true;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
		{
			canMoveUp = true;
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			canMoveUp = false;
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
		{
			canMoveDown = true;
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			canMoveDown = false;
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
		{
			canMoveRight = true;
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			canMoveRight = false;
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
		{
			canMoveLeft = true;
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			canMoveLeft = false;
		}
	}

	private void FixedUpdate()
	{
		if (WaitingToMove())
			return;

		if (canMoveUp && !canMoveDown && 
			PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X, PlayerBrain.CurrentCell.Y +1).TryMoveToCell())
		{
			transform.position += Vector3.up;

			PlayerBrain.UpdateCell(PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X, PlayerBrain.CurrentCell.Y + 1));


			if (OnMovement != null)
			{
				OnMovement();
			}
		}
		else if(!canMoveUp && canMoveDown && 
			PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X, PlayerBrain.CurrentCell.Y - 1).TryMoveToCell())
		{
			transform.position += Vector3.down;

			PlayerBrain.UpdateCell(PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X, PlayerBrain.CurrentCell.Y));


			if (OnMovement != null)
			{
				OnMovement();
			}
		}

		if(canMoveRight && !canMoveLeft && 
			PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X + 1, PlayerBrain.CurrentCell.Y).TryMoveToCell())
		{
			transform.position += Vector3.right;

			PlayerBrain.UpdateCell(PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X + 1, PlayerBrain.CurrentCell.Y));

			if (OnMovement != null)
			{
				OnMovement();
			}
		}
		else if(!canMoveRight && canMoveLeft && 
			PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X - 1, PlayerBrain.CurrentCell.Y).TryMoveToCell())
		{
			transform.position += Vector3.left;

			PlayerBrain.UpdateCell(PlayerBrain.CurrentLevelGrid.GetGridByGridPosition(PlayerBrain.CurrentCell.X - 1, PlayerBrain.CurrentCell.Y));

			if (OnMovement != null)
			{
				OnMovement();
			}
		}
	}
}
