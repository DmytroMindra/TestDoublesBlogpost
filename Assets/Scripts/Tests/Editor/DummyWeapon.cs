using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader.Tests
{
	public class DummyWeapon : IWeapon
	{
		public Shot[] Shoot()
		{
			return null;
		}

		public void Reload()
		{
			throw new NotImplementedException();
		}
	}
}
