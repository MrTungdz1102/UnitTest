namespace UnitTest
{
	public interface ICustomer
	{
		int Discount { get; set; }
		int OrderTotal { get; set; }
		string? GreetMessage { get; set; }
		bool IsPlatinum { get; set; }
		string GreetAndCombineName(string firstName, string lastName);
		CustomerType GetCustomerDetail();
	}
	public class Customer : ICustomer
	{
		public int Discount { get; set; }
		public int OrderTotal { get; set; }
		public string? GreetMessage { get; set; }
		public bool IsPlatinum { get; set; }

		public Customer()
		{
			Discount = 15;
			IsPlatinum = false;
		}
		public string GreetAndCombineName(string firstName, string lastName)
		{
			if (string.IsNullOrWhiteSpace(lastName))
			{
				throw new ArgumentException("Empty LastName");
			}
			GreetMessage = $"Hello, {firstName} {lastName}";
			Discount = 200;
			return GreetMessage;
		}
		public CustomerType GetCustomerDetail()
		{
			if (OrderTotal < 100)
			{
				return new BasicType();
			}
			return new PlatinumType();
		}
	}

	public class CustomerType { }
	public class BasicType : CustomerType { }
	public class PlatinumType : CustomerType { }
}
