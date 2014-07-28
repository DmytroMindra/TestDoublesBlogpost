using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceTrader;

namespace SpaceTrader.Tests
{
	public class SpaceShip : SpaceTrader.ISpaceShip
	{
		List<IWeapon> m_weapons;
		private float m_evasion;
		
		public int WeaponSlots
		{
			get;
			private set;
		}

		public float Evasion
		{
			get 
			{
				return m_evasion;
			}
		}

		public SpaceShip(int weaponSlots, float evasion)
		{
			WeaponSlots = weaponSlots;
			m_evasion = evasion;
			m_weapons = new List<IWeapon>(weaponSlots);
		}

		public bool CanEquip(IWeapon weapon)
		{
			return WeaponSlots > 0;
		}

		public void Equip(IWeapon weapon)
		{
			if (CanEquip(weapon))
			{
				m_weapons.Add(weapon);
			} 
				else
			{
				throw new CantEquipWeaponException();
			}
		}

		public Shot[] Shoot()
		{
			List<Shot> rounds = new List<Shot>();
			foreach (var weapon in m_weapons)
			{
				rounds.AddRange(weapon.Shoot());
			}

			ReloadWeapons();

			return rounds.ToArray();
		}

		public void AcceptIncomingShots(IEnumerable<Shot> round)
		{
		}


		public void ReloadWeapons()
		{
			foreach (var weapon in m_weapons)
			{
				weapon.Reload();
			}
		}


		public int AvailableWeaponSlots
		{
			get { return WeaponSlots - m_weapons.Count(); }
		}
	}
}
