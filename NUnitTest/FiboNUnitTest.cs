using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace NUnitTest
{
	[TestFixture]
	public class FiboNUnitTest
	{
		private Fibo fibo;
		[SetUp]
		public void SetUp()
		{
			fibo = new Fibo();
		}

		[Test]
		[TestCase(1)]
		[TestCase(0)]
		[TestCase(null)]
		[TestCase(6)]
		public void FiboCheck_InputRange_ReturnListFibo(int? range)
		{
			var result = fibo.GetFiboSeries(range);
			if (!range.HasValue)
			{
				CollectionAssert.AreEqual(new List<int> { 0, 1, 1, 2, 3 }, result);
			}
			else if(range == 0 || range == 1)
			{
				CollectionAssert.AreEqual(new List<int> { 0 }, result);
			}
			else
			{
				List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
				Assert.That(result, Is.EquivalentTo(expectedRange));
			}
		}

		[Test]
		[TestCase(1, new int[] { 0, 1, 1, 2, 3 })]
		[TestCase(0, new int[] { 0 })]
		[TestCase(null, new int[] { 0, 1, 1, 2, 3, 5 })]
		[TestCase(6, new int[] { 0, 1, 1, 2, 3, 5 })]
		public void FiboCheckV2_InputRange_ReturnListFibo(int? range, int[] expected)
		{
			var result = fibo.GetFiboSeries(range);
			CollectionAssert.AreEqual(expected, result);
		}
	}
}
