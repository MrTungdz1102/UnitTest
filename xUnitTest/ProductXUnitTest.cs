using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest;

namespace xUnitTest
{
	public class ProductXUnitTest
	{
		[Theory]
		[InlineData(100, true, 80)]
		[InlineData(100, false, 100)]
		public void GetProductPrice_InputCustomerType_ReturnPrice(int price, bool isPlatinum, int grandTotal)
		{
			Product product = new Product { Price = price };
			var result = product.GetPrice(new Customer { IsPlatinum = isPlatinum });
			Assert.Equal(result, grandTotal);
		}

		[Theory]
		[InlineData(100, 80)]
		public void GetPriceUsingMOQ_InputCustomerType_ReturnPrice(double price, double grandTotal)
		{
			Product product = new Product { Price = price };
			var customer = new Mock<ICustomer>();
			customer.Setup(x => x.IsPlatinum).Returns(true);
			Assert.Equal(product.GetPrice(customer.Object), grandTotal);
		}
	}
}
