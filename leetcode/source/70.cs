using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q70
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
		public int ClimbStairs(int n)
		{
			int[] houho = new int[n];
			for (int i = 0; i < n; i++)
			{
				switch (i)
				{
					case 0:
						houho[i] = 1;
						break;
					case 1:
						houho[i] = 2;
						break;
					default:
						houho[i] = houho[i - 1] + houho[i - 2];
						break;
				}
			}
			return houho[n - 1];
		}
	}
}