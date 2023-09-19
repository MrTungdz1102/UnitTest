using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace NUnitTest
{
	[TestFixture]
	public class ProductNUnitTest
	{
		[Test]
		[TestCase(100, true, 80)]
		[TestCase(100, false, 100)]
		public void GetProductPrice_InputCustomerType_ReturnPrice(int price, bool isPlatinum, int grandTotal)
		{
			Product product = new Product { Price = price };
			var result = product.GetPrice(new Customer { IsPlatinum = isPlatinum });
			Assert.That(result, Is.EqualTo(grandTotal));
		}

		[Test]
		[TestCase(100, ExpectedResult = 80)]
		public double GetPriceUsingMOQ_InputCustomerType_ReturnPrice(double price)
		{
			Product product = new Product { Price = price };
			var customer = new Mock<ICustomer>();
			customer.Setup(x => x.IsPlatinum).Returns(true);
			return product.GetPrice(customer.Object);		
		}
	}
}
