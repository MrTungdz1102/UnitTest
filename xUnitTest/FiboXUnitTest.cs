using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace xUnitTest
{
	public class FiboXUnitTest
	{
		private Fibo fibo;
        public FiboXUnitTest()
        {
            fibo = new Fibo();
        }

		[Theory]
		[InlineData(1)]
		[InlineData(0)]
		[InlineData(null)]
		[InlineData(6)]
		public void FiboCheck_InputRange_ReturnListFibo(int? range)
		{
			var result = fibo.GetFiboSeries(range);
			if (!range.HasValue)
			{
				Assert.Equal(new List<int> { 0, 1, 1, 2, 3 }, result);
			}
			else if (range == 0 || range == 1)
			{
				Assert.Equal(new List<int> { 0 }, result);
			}
			else
			{
				List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
				Assert.NotEmpty(result);
				Assert.Equal(expectedRange.OrderBy(x => x), result);
				Assert.True(result.SequenceEqual(expectedRange));
			}
		}

	}
}
