using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader.Tests
{
	public class Encounter
	{
		private ISpaceShip player;
		private ISpaceShip opponent;
		private IRandomNumberService randomNumberService;

		public Encounter(ISpaceShip player, ISpaceShip opponent, IRandomNumberService randomNumberService)
		{
			this.player = player;
			this.opponent = opponent;
			this.randomNumberService = randomNumberService;
		}

		public void Attack()
		{
			var evasionChance = opponent.Evasion;
			var shots = player.Shoot();
			List<Shot> hits = new List<Shot>();

			foreach (var shot in shots)
			{
				var hitChance = randomNumberService.Range(0, 100);
				if (hitChance > evasionChance) hits.Add(shot);
			}
			opponent.AcceptIncomingShots(hits.ToArray());
		}
	}
}
