using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace SpaceTrader.Tests
{
	public class EncounterTests
	{

		[Test]
		public void OpponentGetHitInAnEncounter_OnAttack()
		{
			// Arrange
			var opponent = new SpaceShipSpy();
			var player = SpaceShipWithTwoFunctionalWeaponStubs();
			var randomNumberService = AlwaysMaxRandomNumber();
			var encounter = new Encounter(player, opponent, randomNumberService);
			
			// Act
			encounter.Attack();

			// Assert
			Assert.That(opponent.HitsCount, Is.EqualTo(2));
		}


		[Test]
		public void OpponentGetsNoHitsInEncounter_OnAttack()
		{
			// Arrange

			int hitCount = 0;
			var opponent = Substitute.For<ISpaceShip>();
			opponent.AcceptIncomingShots (Arg.Do<IEnumerable<Shot>>(x => hitCount+=x.Count()) );

			var player = SpaceShipWithTwoFunctionalWeaponStubs();
			var randomNumberService = AlwaysMinRandomNumber();
			var encounter = new Encounter(player, opponent, randomNumberService);

			// Act
			encounter.Attack();

			// Assert
			Assert.That(hitCount,Is.EqualTo(0));
		}

		private IRandomNumberService HitAndMissRandomService()
		{
			var randomNumberService = Substitute.For<IRandomNumberService>();
			randomNumberService.Range(0, 0).ReturnsForAnyArgs(100, 0);
			return randomNumberService;
		}

		private ISpaceShip SpaceShipWithTwoFunctionalWeaponStubs()
		{
			var spaceship = new SpaceShip(2, 0);
			spaceship.Equip(new FunctionalWeaponStub());
			spaceship.Equip(new FunctionalWeaponStub());
			return spaceship;
		}

		private static IRandomNumberService AlwaysMaxRandomNumber()
		{
			var randomNumberService = Substitute.For<IRandomNumberService>();
			randomNumberService.Range(Arg.Any<float>(), Arg.Any<float>()).Returns((x) => x[1]);
			return randomNumberService;
		}

		private static IRandomNumberService AlwaysMinRandomNumber()
		{
			var randomNumberService = Substitute.For<IRandomNumberService>();
			randomNumberService.Range(Arg.Any<float>(), Arg.Any<float>()).Returns(x => x[0]);
			return randomNumberService;
		}

	}
}
