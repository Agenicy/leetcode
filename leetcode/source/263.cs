using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q263
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool IsUgly(int n)
		{
			if (n == 0)
				return false;
			foreach (var prime in new[] { 2, 3, 5 })
				while (n % prime == 0)
					n /= prime;
			return n == 1;
		}
	}
}