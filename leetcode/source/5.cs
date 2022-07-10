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

			Console.WriteLine(solution.LongestPalindrome("xxcxcabacabac"));
			Console.WriteLine("The answer should be  cabacabac");
			Console.WriteLine(solution.LongestPalindrome("babad"));
			Console.WriteLine("The answer should be bab/ aba");
			Console.WriteLine(solution.LongestPalindrome("cbbd"));
			Console.WriteLine("The answer should be bb");
		}
	}
	public class Solution
	{
		string GetRow(int[,] matrix, int row)
		{
			var colLength = matrix.GetLength(0);
			var ret = "";

			for (var i = 0; i < colLength; i++)
				ret += $"{matrix[row, i]},";

			return ret;
		}

		public string LongestPalindrome(string s)
		{
			/* This prob equals to : the Longest Common Substring between s and reverse s.
			 * By https://www.geeksforgeeks.org/longest-common-substring-dp-29/
			 * the Longest Common Substring can solved by dp
			 * LCSuff(X, Y, m, n) = LCSuff(X, Y, m-1, n-1) + 1 if X[m-1] = Y[n-1] 
			 * So, LCSuff(X, X, m, n) = LCSuff(X, X, m-1, n+1) + 1 if X[m-1] =X[n+1] 
			 */
			int maxR = 0, max = 0;
			int[,] dp = new int[s.Length+1, s.Length+1];
			for (int i = 1; i < s.Length+1; i++)
			{
				for (int j = 1; j < s.Length+1; j++)
				{
					if (s[i - 1] == s[s.Length - j])
					{
						dp[i, j] = dp[i - 1, j - 1] + 1;
						if (dp[i, j] > max)
						{
							max = dp[i, j];
							maxR = i;
						}
					}
					else
						dp[i, j] = 0;
				}
			}
			return s.Substring(maxR - max, max);
		}
	}
}