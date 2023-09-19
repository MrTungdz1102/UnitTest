using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	public class BankAccount
	{
        public int Balance { get; set; }
        private readonly ILogBook _log;
        public BankAccount(ILogBook log)
        {
            Balance = 0;
            _log = log;
        }
        public bool Deposit(int amount)
        {
            Balance += amount;
            _log.Message("Deposit Success");
            return true;
        }

		public bool DepositValid(int amount)
		{
			Balance += amount;
			_log.Message("Deposit Success");
			_log.Message("Test");
			_log.LogSeverity = 101;
			return true;
		}

		//     public bool WithDraw(int amount)
		//     {
		//         if(Balance >= amount)
		//         {
		//             Balance -= amount;
		//_log.Message("WithDraw Success");
		//	return true;
		//         }
		//         return false;
		//     }

		public bool WithDraw(int amount)
		{
			if (Balance >= amount)
			{
				Balance -= amount;
				_log.LogToDb("Withdraw amount" + amount);
				return _log.LogBalanceAfterWithDraw(Balance);
			}
			return _log.LogBalanceAfterWithDraw(Balance - amount);
		}

		public int GetBalance()
        {
            return Balance;
        }
    }
}
