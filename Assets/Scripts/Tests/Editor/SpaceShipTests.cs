using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace SpaceTrader.Tests
{
	public class SpaceShipTests
	{

		//var harmlessWeaponStub = Substitute.For<IWeapon>();
		//harmlessWeaponStub.Shoot().Returns(new [] { new Shot(0,0,0)});

		[Test]
		public void SpaceShipShootsAtLeastOneShot_WhenFunctionalWeaponIsEquiped()
		{
			// Arrange
			var ship = SpaceShipWithSingleWeaponSlot();

			var functionalWeaponStub = Substitute.For<IWeapon>();
			functionalWeaponStub.Shoot().Returns(new[] { new Shot(0, 0, 0) });
			ship.Equip(functionalWeaponStub);

			// Act
			var round = ship.Shoot();

			// Assert
			var roundContainsOneShot = round.Length == 1;
			Assert.That(roundContainsOneShot);
		}


		[Test]
		public void EachWeaponShoots_WhenSpaceShipShootIsCalled()
		{
			// Arrange
			var weapon1 = Substitute.For<IWeapon>();
			var weapon2 = Substitute.For<IWeapon>();

			var ship = new SpaceShip(2, 0);
			ship.Equip(weapon1);
			ship.Equip(weapon2);

			// Act
			ship.Shoot();
			
			// Assert
			weapon1.Received(1).Shoot();
			weapon2.Received(1).Shoot();
		}

		[Test]
		public void EachWeaponGetsReloaded_AfterItIsShot()
		{
			// Arrange
			var weapon1 = Substitute.For<IWeapon>();
			var weapon2 = Substitute.For<IWeapon>();

			var ship = new SpaceShip(2, 0);
			ship.Equip(weapon1);
			ship.Equip(weapon2);

			// Act
			ship.Shoot();

			// Assert	
			Received.InOrder(() =>
				{
					weapon1.Shoot();
					weapon2.Shoot();
					weapon1.Reload();
					weapon2.Reload();
				}
			);
		}

		//[Test]
		//public void NoWeaponSlotsAvailable_AfterWeaponIsEquiped()
		//{
		//	// Arrange
		//	SpaceShip spaceShip = SpaceShipWithSingleWeaponSlot();
		//	IWeapon weapon = NSubstitute.Substitute.For<IWeapon>();
		//	// Act
		//	spaceShip.Equip(weapon);
		//	// Assert
		//	var noWeaponSlotsAvailable = spaceShip.AvailableWeaponSlots == 0;
		//	Assert.That(noWeaponSlotsAvailable);
		//}


		[Test]
		public void NoWeaponSlotsAvailable_AfterWeaponIsEquiped()
		{
			// Arrange
			SpaceShip spaceShip = SpaceShipWithSingleWeaponSlot();
			IWeapon weapon = new DummyWeapon();
			// Act
			spaceShip.Equip(weapon);
			// Assert
			var noWeaponSlotsAvailable = spaceShip.AvailableWeaponSlots == 0;
			Assert.That(noWeaponSlotsAvailable);
		}

		private static SpaceShip SpaceShipWithSingleWeaponSlot()
		{
			SpaceShip spaceShip = new SpaceShip(1, 0);
			return spaceShip;
		}

	}
}
