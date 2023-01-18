using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q926
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MinFlipsMonoIncr("0"));
			Log.Print(solution.MinFlipsMonoIncr("1"));
			Log.Print(solution.MinFlipsMonoIncr("1111001110"));
			Log.Print(solution.MinFlipsMonoIncr("00011000"));
			Log.Print(solution.MinFlipsMonoIncr("11011"));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MinFlipsMonoIncr(string s)
		{
			int chaosStart, chaosEnd;
			for (chaosStart = 0; chaosStart < s.Length; chaosStart++)
			{
				if (s[chaosStart] == '1')
					break;
			}
			for (chaosEnd = s.Length; chaosEnd > 0; chaosEnd--)
			{
				if (s[chaosEnd - 1] == '0')
					break;
			}

			int[,] dp = new int[chaosEnd - chaosStart + 1, 2];
			for (int i = 1; i < dp.GetLength(0); i++)
			{
				dp[i, 0] = s[chaosStart + i - 1] - '0' + dp[i - 1, 0];
				dp[dp.GetLength(0) - 1 - i, 1] = '1' - s[chaosEnd - i] + dp[dp.GetLength(0) - i, 1];
			}
			int min = int.MaxValue;
			for (int i = 0; i < dp.GetLength(0); i++)
			{
				min = Math.Min(min, dp[i, 0] + dp[i, 1]);
			}
			return min;
		}
	}
}