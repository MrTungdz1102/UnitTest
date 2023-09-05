using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace MSTest
{
	[TestClass]
	public class CaculatorMSTest
	{
		[TestMethod]
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
	}
}
