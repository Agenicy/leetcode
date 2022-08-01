using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q62
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
		public int UniquePaths(int m, int n)
		{
			int[] row = new int[n];
			for (int i = 0; i < n; i++)
			{
				row[i] = 1;
			}
			for (int i = 1; i < m; i++)
			{
				for (int j = 1; j < n; j++)
				{
					row[j] += row[j - 1];
				}
			}
			return row[n - 1];
		}
	}
}