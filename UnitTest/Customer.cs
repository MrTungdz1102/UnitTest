using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	public class Customer
	{
		public int Discount { get; set; } = 15;
		public int OrderTotal { get; set; }
		public string GreetMessage { get; set; }
		public string GreetAndCombineName(string firstName, string lastName) {
			if(string.IsNullOrWhiteSpace(lastName))
			{
				throw new ArgumentException("Empty LastName");
			}
			GreetMessage =  $"Hello, {firstName} {lastName}";
			Discount = 200;
			return GreetMessage;
		}
		public CustomerType GetCustomerDetail() {
			if(OrderTotal < 100)
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
