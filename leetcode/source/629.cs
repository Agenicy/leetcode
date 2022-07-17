using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace leetcode.Q629
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.KInversePairs(5, 3));
			Console.WriteLine(solution.KInversePairs(100, 100));
			Console.WriteLine(solution.KInversePairs(3, 0));
			Console.WriteLine(solution.KInversePairs(3, 1));
			Console.WriteLine("The answer should be 959322173/ 1/ 2");
		}
	}

	public class Solution
	{
		public int KInversePairs(int n, int k)
		{
			int[,] dp = new int[n + 1,k + 1];
			int M = 1000000007;
			for (int i = 1; i <= n; i++)
			{
				for (int j = 0; j <= k && j <= i * (i - 1) / 2; j++)
				{
					if (i == 1 && j == 0)
					{
						dp[i,j] = 1;
						break;
					}
					else if (j == 0)
						dp[i,j] = 1;
					else
					{
						int val = (dp[i - 1,j] + M - ((j - i) >= 0 ? dp[i - 1,j - i] : 0)) % M;
						dp[i,j] = (dp[i,j - 1] + val) % M;
					}
				}
			}
			return dp[n,k];
		}
	}
}