
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace xUnitTest
{
	public class GradingCalculatorXUnitTest
	{
		private GradingCalculator gradingCalculator;
        public GradingCalculatorXUnitTest()
        {
            gradingCalculator = new GradingCalculator();
        }
        [Fact]
		public void GradeCalc_InputScoreAndAttendPercent()
		{
			// also use ExpectedResult 
			string result = gradingCalculator.GetGrade(95, 80);
			Assert.Equal("A", result);
		}

		[Theory]
		[InlineData(95, 80, "A")]
		[InlineData(85, 90, "B")]
		[InlineData(65, 90, "C")]
		[InlineData(95, 65, "B")]
		[InlineData(95, 55, "F")]
		[InlineData(65, 55, "F")]
		[InlineData(50, 90, "F")]
		public void GradeCalc2_InputScoreAndAttendPercent(int score, int attentPercent, string expectedGrade)
		{
			// also use ExpectedResult 
			string result = gradingCalculator.GetGrade(score, attentPercent);
			Assert.Equal(expectedGrade, result);
		}
	}
}
