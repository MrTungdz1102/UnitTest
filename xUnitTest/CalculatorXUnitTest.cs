using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace xUnitTest
{
	public class CalculatorXUnitTest
	{
		[Fact]
		public void AddNumbers_InputTwoInt_GetCorrectAddition()
		{
			Calculator calc = new Calculator();
			int result = calc.AddNumbers(1, 2);
			Assert.Equal(3, result);
		}
	}
}
