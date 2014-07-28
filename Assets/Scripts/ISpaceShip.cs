using System;
using System.Collections.Generic;
using SpaceTrader.Tests;
namespace SpaceTrader
{
	//public interface ISpaceShip
	//{
	//	void Equip(IWeapon weapon);
	//}

	
	public interface ISpaceShip
	{
		int WeaponSlots { get; }
		int AvailableWeaponSlots { get; }
		float Evasion { get; }

		bool CanEquip(SpaceTrader.Tests.IWeapon weapon);
		void Equip(SpaceTrader.Tests.IWeapon weapon);
		Shot[] Shoot();
		void ReloadWeapons();

		void AcceptIncomingShots(IEnumerable<Shot> round);
	}
}
