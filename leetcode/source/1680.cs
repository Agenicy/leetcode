using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace leetcode.Q1680
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			//Log.Print(solution.ConcatenatedBinary(1));
			Log.Print(solution.ConcatenatedBinary(3));
			Log.Print(solution.ConcatenatedBinary(12));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		const int mod = 0b11_1011_1001_1010_1100_1010_0000_0111;
		public int ConcatenatedBinary(int n)
		{
			int sum = 0;
			long times = 1;
			for (int i = n; i > 0; i--)
			{
				checked
				{

					int add = (int)((i * (times % mod)) % mod);
					sum = (sum + add) % mod;
					times = (times * (1 << ((int)Math.Floor(Math.Log2(i)) + 1))) % mod;
				}
			}
			return sum;
		}
	}
}