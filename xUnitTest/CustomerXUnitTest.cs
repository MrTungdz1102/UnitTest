using UnitTest;

namespace xUnitTest
{
	public class CustomerXUnitTest
	{
		private Customer customer;
		public CustomerXUnitTest()
		{
			customer = new Customer();
		}
		[Fact]
		public void CombineName_InputTwoString_OutputFullName()
		{

			string fullName = customer.GreetAndCombineName("Tung", "Dao");
			// co the su dung AreEqual(fullName, "Hello, Tung Dao");
			Assert.Multiple(
				() => Assert.Equal("Hello, Tung Dao", customer.GreetMessage),
				() => Assert.Contains(",", fullName),
				// ignorecase k phan biet chu hoa chu thuong
				() => Assert.StartsWith("hello", fullName, StringComparison.InvariantCultureIgnoreCase),
				() => Assert.Matches(("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"), fullName)
			);
		}

		[Fact]
		public void GreetMessage_NotGreeted_ReturnNull()
		{

			//	customer.GreetAndCombineName("Tung", "Dao");
			Assert.Null(customer.GreetMessage);
		}

		[Fact]
		public void DiscountCheck_DefaultCustomer_ReturnDiscountRange()
		{
			int result = customer.Discount;
			Assert.InRange(result, 10, 20);
		}

		[Fact]
		public void GreetMessage_GreetWithoutLastName_ReturnNull()
		{
			// exception
			var exception = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineName("tung", "   "));
			//	Assert.That(() => customer.GreetAndCombineName("tung", "   "), Throws.ArgumentException.With.Message.EqualTo("Empty LastName"));
				Assert.Equal("Empty LastName", exception.Message);

		//	Assert.Throws(() => customer.GreetAndCombineName("tung", "   "), Throws.ArgumentException);
		}

		[Fact]
		public void CustomerType_ReturnTypeOfCustomer()
		{
			customer.OrderTotal = 10;
			var result = customer.GetCustomerDetail();
			Assert.IsType<BasicType>(result);
			customer.OrderTotal = 200;
			result = customer.GetCustomerDetail();
			Assert.IsType<PlatinumType>(result);
		}
	}
}
