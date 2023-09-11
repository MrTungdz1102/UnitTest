using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace NUnitTest
{
	[TestFixture]
	public class CustomerNUnitTest
	{
		private Customer? customer;
		[SetUp]
		public void SetUp()
		{
			customer = new Customer();
		}


		[Test]
		public void CombineName_InputTwoString_OutputFullName()
		{
			
			string fullName = customer.GreetAndCombineName("Tung", "Dao");
			// co the su dung AreEqual(fullName, "Hello, Tung Dao");
			Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Tung Dao"));
			Assert.That(fullName, Does.Contain(","));
			// ignorecase k phan biet chu hoa chu thuong
			Assert.That(fullName, Does.StartWith("hello").IgnoreCase);
			Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
		}

		[Test]
		public void GreetMessage_NotGreeted_ReturnNull()
		{
			
		//	customer.GreetAndCombineName("Tung", "Dao");
			Assert.IsNull(customer.GreetMessage);
		}
	}
}
