using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q5
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.LongestPalindrome("aacabdkacaa"));
			Console.WriteLine("The answer should be aca");
			Console.WriteLine(solution.LongestPalindrome("babad"));
			Console.WriteLine("The answer should be bab/ aba");
			Console.WriteLine(solution.LongestPalindrome("cbbd"));
			Console.WriteLine("The answer should be bb");
			Console.WriteLine(solution.LongestPalindrome("xxcxcabacabac"));
			Console.WriteLine("The answer should be  cabacabac");
		}

	}
	public class Solution
	{
		public string LongestPalindrome(string s)
		{
			if (s.Length == 1 || (s.Length == 2 && s[0] == s[1]))
				return s;
			/* 
			 * R(s, m, n) = 0 if R(s, m+1, n-1) == 0 || s[m+1] != s[n-1]
			 * R(s, m, n) = R(s, m+1, n-1) + 1 if s[m+1] == s[n-1]
			 */
			int maxR = 0, max = 1;
			int[,] dp = new int[s.Length, s.Length];
			for (int i = 0; i < s.Length; i++)
			{
				for (int j = 1; j <= 2 && i + j < s.Length; j++)
				{
					if (s[i] == s[i + j])
						dp[i, i + j] = j + 1;
					if (dp[i, i + j] > max)
					{
						max = dp[i, i + j];
						maxR = i;
					}
				}
			}
			for (int i = s.Length - 1; i >= 0; i--)
			{
				for (int j = i + 2; j < s.Length; j++)
				{
					if (dp[i, j] != 0)
						continue;

					if (s[i] != s[j])
						dp[i, j] = 0;
					else if (dp[i + 1, j - 1] == 0)
						dp[i, j] = 0;
					else
					{
						dp[i, j] = dp[i + 1, j - 1] + 2;
						if (dp[i, j] > max)
						{
							max = dp[i, j];
							maxR = i;
						}
					}
				}
			}
			return s.Substring(maxR, max);
		}
	}
}