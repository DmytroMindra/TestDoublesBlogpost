using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader.Tests
{
	public class SpaceShipDummy: ISpaceShip
	{
		public virtual int WeaponSlots
		{
			get { return default(int); }
		}

		public virtual int AvailableWeaponSlots
		{
			get { return default(int); }
		}

		public virtual float Evasion
		{
			get { return default(float); }
		}

		public virtual bool CanEquip(IWeapon weapon)
		{
			return default(bool);
		}

		public virtual void Equip(IWeapon weapon)
		{
		}

		public virtual Shot[] Shoot()
		{
			return null;
		}

		public virtual void ReloadWeapons()
		{
		}

		public virtual void AcceptIncomingShots(IEnumerable<Shot> round)
		{
		}
	}
}
