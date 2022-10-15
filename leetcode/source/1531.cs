using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1531
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.GetLengthOfOptimalCompression("aaabcccd", 2));
			Log.Print("The answer should be 4");
		}
	}
	public class Solution
	{
		public int GetLengthOfOptimalCompression(string s, int k)
		{
			int[,] dp = new int[101, 101];
			for (int i = 0; i < 101; i++)
				for (int j = 0; j < 101; j++)
					dp[i, j] = -1;

			int dfs(int left, int K)
			{
				int k = K;
				if (s.Length - left <= k) return 0;
				if (dp[left, k] >= 0) return dp[left, k];
				int res = k > 0 ? dfs(left + 1, k - 1) : 10000, c = 1;
				for (int i = left + 1; i <= s.Length; ++i)
				{
					res = Math.Min(res, dfs(i, k) + 1 + (c >= 100 ? 3 : (c >= 10 ? 2 : (c > 1 ? 1 : 0))));
					if (i == s.Length) break;
					if (s[i] == s[left]) ++c;
					else if (--k < 0) break;
				}
				return dp[left, K] = res;
			}
			return dfs(0, k);
		}
	}
}