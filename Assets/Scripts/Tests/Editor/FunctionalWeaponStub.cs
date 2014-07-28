using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader.Tests
{
	class FunctionalWeaponStub: IWeapon
	{
		public Shot[] Shoot()
		{
			return new[] { new Shot(0, 0, 0) };
		}

		public void Reload()
		{
		}
	}
}
