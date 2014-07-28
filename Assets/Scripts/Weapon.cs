using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceTrader;

namespace SpaceTrader.Tests
{
	public interface IWeapon
	{
		Shot[] Shoot();
		void Reload();
	}
}
