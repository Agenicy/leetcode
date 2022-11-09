using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q901
{
	public class Program
	{
		public static void Run()
		{
			StockSpanner stockSpanner = new StockSpanner();
			Log.Print(stockSpanner.Next(100));
			Log.Print(stockSpanner.Next(80));
			Log.Print(stockSpanner.Next(60));
			Log.Print(stockSpanner.Next(70));
			Log.Print(stockSpanner.Next(60));
			Log.Print(stockSpanner.Next(75));
			Log.Print(stockSpanner.Next(101));
			Log.Print("The answer should be ");
		}
	}
	public class StockSpanner
	{
		int day;
		Stack<(int, int)> stack;
		public StockSpanner()
		{
			day = 0;
			stack = new();
			stack.Push((int.MaxValue, 0));
		}

		public int Next(int price)
		{
			++day;
			while(stack.Peek().Item1 <= price)
				stack.Pop();

			int res = day - stack.Peek().Item2;
			stack.Push((price, day));
			return res;
		}
	}

	/**
	 * Your StockSpanner object will be instantiated and called as such:
	 * StockSpanner obj = new StockSpanner();
	 * int param_1 = obj.Next(price);
	 */
}