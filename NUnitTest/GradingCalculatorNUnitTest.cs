using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace NUnitTest
{
	[TestFixture]
	public class GradingCalculatorNUnitTest
	{
		private GradingCalculator gradingCalculator;
		[SetUp]
		public void SetUp()
		{
			gradingCalculator = new GradingCalculator();
		}

		[Test]
		[TestCase(95, 80, "A")]
		[TestCase(85, 90, "B")]
		[TestCase(65, 90, "C")]
		[TestCase(95, 65, "B")]
		[TestCase(95, 55, "F")]
		[TestCase(65, 55, "F")]
		[TestCase(50, 90, "F")]
		public void GradeCalc_InputScoreAndAttendPercent(int score, int attentPercent, string expectedGrade)
		{
			// also use ExpectedResult 
			string result = gradingCalculator.GetGrade(score, attentPercent);
			Assert.AreEqual(expectedGrade, result);
		}
	}
}
