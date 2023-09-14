using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	public class Fibo
	{
		public int Range { get; set; }
		public Fibo()
		{
			Range = 5;
		}
		public List<int> GetFiboSeries(int? range){
			Range = range ?? Range;
			List<int> fiboSeries = new List<int>();
			int a = 0, b = 1, c = 0;
			if(Range == 1 || Range ==0)
			{
				fiboSeries.Add(0);
				return fiboSeries;
			}
			fiboSeries.Add(0);
			fiboSeries.Add(1);
			for (int i = 2; i < Range; i++)
			{
				c = a + b;
				fiboSeries.Add(c);
				a = b;
				b = c;
			}
			return fiboSeries;
		}
	}
}
