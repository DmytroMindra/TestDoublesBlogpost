using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader.Tests
{
	public class SpaceShipSpy : SpaceShipDummy
	{
		public int HitsCount { get; set; }

		public override void AcceptIncomingShots(IEnumerable<Shot> shots)
		{
			HitsCount+=shots.Count();
		}
	}
}
