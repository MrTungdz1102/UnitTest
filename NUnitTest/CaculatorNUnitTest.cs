using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace NUnitTest
{
	[TestFixture]
	public class CaculatorNUnitTest
	{
		[Test]
		public void AddNumbers_InputTwoInt_GetCorrectAddition()
		{
			// 3 giai doan
			// arrange phase : khoi tao
			Caculator calc = new Caculator();



			// act phase : action
			int result = calc.AddNumbers(1, 2);

			// assert phase : check result
			Assert.AreEqual(3, result);
		}

		[Test]
		[TestCase(11)]
		[TestCase(9)]
		public void OddNumber_InputOneInt_GetCorrectAddition(int a)
		{
			// [Range(1, 10)] int a

			Caculator calc = new Caculator();
			var result = calc.IsOddNumber(a);
		//	Assert.IsTrue(result);
			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		[TestCase(13, ExpectedResult = true)]
		[TestCase(12, ExpectedResult = false)]
		public bool OddNumber_InputOneInt(int a)
		{
			Caculator calc = new Caculator();
			return calc.IsOddNumber(a);
		}

		[Test]
		[TestCase(13.4, 12.65)] // 26.05
		[TestCase(13.55, 12.65)] // 26.20
		[TestCase(13.45, 12.15)] // 25.6
		public void AddDoubleNumbers_InputTwoDouble_GetCorrectAddition(double a, double b)
		{
			Caculator calc = new Caculator();

			double result = calc.AddDoubleNumbers(a, b);
			// delta = chenh lech ket qua
			Assert.AreEqual(26.055, result, .01);
		}
	}
}
