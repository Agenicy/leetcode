using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1155
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.NumRollsToTarget(3, 6, 18));
			Log.Print(solution.NumRollsToTarget(1, 6, 3));
			Log.Print(solution.NumRollsToTarget(2, 6, 7));
			Log.Print(solution.NumRollsToTarget(30, 30, 500));
			Log.Print("The answer should be 1/ 6/ 222616187");
		}
	}
	public class Solution
	{
		const int mod = (int)1e9 + 7;
		public int NumRollsToTarget(int n, int k, int target)
		{
			if (target < n)
				return 0;

			int[,] dp = new int[n, target+1];

			for (int faceCount = 1; faceCount <= k && faceCount <= target; faceCount++)
				dp[0, faceCount] = 1;

			for (int diceCount = 2; diceCount <= n; diceCount++)
			{
				for (int ind = Math.Min(diceCount * k, target); ind >= diceCount; ind--)
				{
					for (int faceCount = k; faceCount > 0; faceCount--)
					{
						if (ind - faceCount > 0)
							dp[diceCount-1, ind] = (dp[diceCount-1, ind] + dp[diceCount - 2, ind - faceCount]) % mod;
					}
				}
			}

			return (int)(dp[n-1, target] % mod);
		}
	}
}