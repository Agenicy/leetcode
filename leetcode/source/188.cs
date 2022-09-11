using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q188
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MaxProfit(2, Parser.ParseArr1D("[2,4,1]")));
			Log.Print(solution.MaxProfit(2, Parser.ParseArr1D("[3,2,6,5,0,3]")));
			Log.Print("The answer should be 2/ 7");
		}
	}
	public class Solution
	{
		public int MaxProfit(int k, int[] prices)
		{
			int[,] dp = new int[k + 1, 2];

			if (k == 0) return 0;

			for (int i = 0; i <= k; i++) dp[i, 0] = int.MaxValue;
			foreach (var price in prices)
			{
				for (int i = 1; i <= k; i++)
				{
					// price - dp[i - 1][1] is how much you need to spend
					// i.e use the profit you earned from previous transaction to buy the stock
					// we want to minimize it
					dp[i, 0] = Math.Min(dp[i, 0], price - dp[i - 1, 1]);
					// price - dp[i][0] is how much you can achieve from previous min cost
					// we want to maximize it
					dp[i, 1] = Math.Max(dp[i, 1], price - dp[i, 0]);
				}
			}
			return dp[k, 1];
		}
	}
}