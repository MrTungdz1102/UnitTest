using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	public interface ILogBook
	{
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        void Message(string message);
		bool LogToDb(string message);
		bool LogBalanceAfterWithDraw(int balance);
		string MessageWithReturnStr(string message);
		bool LogWithOutPutResult(string str, out string outputStr);
		bool LogWithRefObject(ref Customer customer);
	}
	public class LogBook : ILogBook
	{
		public int LogSeverity { get; set; }
		public string LogType { get; set; }

		public bool LogBalanceAfterWithDraw(int balance)
		{
			if(balance >= 0)
			{
				Console.WriteLine("Success");
				return true;
			}
			Console.WriteLine("Failure");
			return false;	
		}

		public bool LogToDb(string message)
		{
			Console.WriteLine(message);
			return true;
		}

		public bool LogWithOutPutResult(string str, out string outputStr)
		{
			outputStr = "Hello" + str;
			return true;
		}

		public bool LogWithRefObject(ref Customer customer)
		{
			return true;
		}

		public void Message(string message)
		{
            Console.WriteLine(message);
        }

		public string MessageWithReturnStr(string message)
		{
            Console.WriteLine(message);
			return message.ToLower();
        }
	}

	public class LogFake : ILogBook
	{
		public int LogSeverity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public string LogType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public bool LogBalanceAfterWithDraw(int balance)
		{
			throw new NotImplementedException();
		}

		public bool LogToDb(string message)
		{
			throw new NotImplementedException();
		}

		public bool LogWithOutPutResult(string str, out string outputStr)
		{
			throw new NotImplementedException();
		}

		public bool LogWithRefObject(ref Customer customer)
		{
			throw new NotImplementedException();
		}

		public void Message(string message)
		{
			
		}

		public string MessageWithReturnStr(string message)
		{
			throw new NotImplementedException();
		}
	}
}
