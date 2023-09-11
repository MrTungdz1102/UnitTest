using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	public class Customer
	{
		public string GreetMessage { get; set; }
		public string GreetAndCombineName(string firstName, string lastName) {
			GreetMessage =  $"Hello, {firstName} {lastName}";
			return GreetMessage;
		}
	}
}
