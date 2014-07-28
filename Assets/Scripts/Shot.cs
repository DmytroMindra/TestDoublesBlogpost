using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader
{
	public class Shot
	{
		public Shot(float beamDamage, float physicalDamage, float shieldPenetration)
		{
			BeamDamage = beamDamage;
			physicalDamage = physicalDamage;
			shieldPenetration = shieldPenetration;
		}


		public float BeamDamage { get; private set; }
		public float PhysicalDamage { get; private set; }
		public float ShieldPenetration { get; private set; }
	}
}
