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
		private Calculator caculator;
		[SetUp]
		public void SetUp()
		{
			caculator = new Calculator();
		} 

		[Test]
		public void AddNumbers_InputTwoInt_GetCorrectAddition()
		{
			// 3 giai doan
			// arrange phase : khoi tao
			Calculator calc = new Calculator();



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

			Calculator calc = new Calculator();
			var result = calc.IsOddNumber(a);
		//	Assert.IsTrue(result);
			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		[TestCase(13, ExpectedResult = true)]
		[TestCase(12, ExpectedResult = false)]
		public bool OddNumber_InputOneInt(int a)
		{
			Calculator calc = new Calculator();
			return calc.IsOddNumber(a);
		}

		[Test]
		[TestCase(13.4, 12.65)] // 26.05
		[TestCase(13.55, 12.65)] // 26.20
		[TestCase(13.45, 12.15)] // 25.6
		public void AddDoubleNumbers_InputTwoDouble_GetCorrectAddition(double a, double b)
		{
			Calculator calc = new Calculator();

			double result = calc.AddDoubleNumbers(a, b);
			// delta = chenh lech ket qua
			Assert.AreEqual(26.055, result, .5);
		}

		[Test]
		[TestCase(5, 10)]
		public void GetRangeOddNumber_InputMinMaxNumber_GetCorrectCondition(int a, int b)
		{
			var result = caculator.GetOddRange(a, b);
			List<int> expectedNumbers = new List<int> {5, 7, 9};
			// Assert.AreEqual(expectedNumbers, result);
			Assert.That(result, Is.EquivalentTo(expectedNumbers));
			Assert.Contains(5, result);
			Assert.That(result, Is.Not.Empty);
			Assert.That(result.Count, Is.EqualTo(3));
			// is de so sanh kq, does de thuc hien hanh dong
			// has dung de kiem tra thuoc tinh cua doi tuong
			Assert.That(result, Has.No.Member(6));
			// sap sep tang dan
			Assert.That(result, Is.Ordered);
			Assert.That(result, Is.Unique);
		}
	}
}
