using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q91
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.NumDecodings("1201234"));
			Log.Print(solution.NumDecodings("27"));
			Log.Print(solution.NumDecodings("2101"));
			Log.Print(solution.NumDecodings("1123"));
			Log.Print("The answer should be 3/ 1/ 1/ 5");
		}
	}
	public class Solution
	{
		public int NumDecodings(string s)
		{
			int[] dp = new int[s.Length];
			if (s[0] == '0')
				return 0;
			else
				dp[0] = 1;

			for (int i = 1; i < s.Length; i++)
			{
				if (s[i] == '0')
				{
					if (s[i - 1] != '1' && s[i - 1] != '2')
						return 0;

					dp[i] = (i >= 2) ? dp[i - 2] : 1;
				}
				else
				{
					// 1 - 9

					if (s[i - 1] == '0')
					{
						// X0, 1 ~ X0, 9
						dp[i] = dp[i - 1];
					}
					else
					{
						// XX, I ~ X, XI
						if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] <= '6'))
							dp[i] = dp[i - 1] + (i >= 2 ? dp[i - 2] : 1);
						else
							dp[i] = dp[i - 1];
					}

				}
			}
			return dp[dp.Length - 1];
		}
	}
}