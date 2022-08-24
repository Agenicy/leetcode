using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q326
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
		public bool IsPowerOfThree(int n)
		{
			if (n == 1) return true;
			if (n < 3 || n % 3 != 0) return false;
			else if (n == 3) return true;
			else return IsPowerOfThree(n / 3);
		}
	}
}