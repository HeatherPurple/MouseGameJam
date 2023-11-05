﻿namespace GameJob.Features.CardSystem
{
	using UnityEngine;
	[CreateAssetMenu(fileName = "MakeLavaCard", menuName = "Cards/MakeLavaCard")]
	public class MakeLavaCard: AbstractCard
	{
		public override void ActivateCard()
		{
			Debug.Log("MakeLavaCard");
		}
	}
}