using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceTrader.Tests
{
	public interface IRandomNumberService
	{
		float Range(float min, float max);
	}
}
