using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrainElement : MonoBehaviour
{
	private PlayerBrain playerBrain;
	public PlayerBrain PlayerBrain
	{
		get
		{
			return playerBrain;
		}
	}

	public void SetUpBrain(PlayerBrain brain)
	{
		playerBrain = brain;
	}

}
