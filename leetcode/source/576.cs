using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q576
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.FindPaths(36, 5, 50, 15, 3));
			Console.WriteLine(solution.FindPaths(2, 3, 8, 1, 0));
			Console.WriteLine(solution.FindPaths(1, 2, 50, 0, 0));
			Console.WriteLine(solution.FindPaths(2, 2, 2, 0, 0));
			Console.WriteLine(solution.FindPaths(1, 3, 3, 0, 1));
			Console.WriteLine("The answer should be 390153306/ 1104/ 150/ 6/ 12");
		}
	}
	public class Solution
	{
		public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
		{
			const int mod = (int)(1e9 + 7);

			int[,] ints = new int[m, n];
			int[,] next = new int[m, n];
			int[,] original = new int[m, n];

			foreach (var i in new[] { 0, m - 1 })
			{
				for (int j = 0; j < n; j++)
				{
					original[i, j]++;
				}
			}
			foreach (var j in new[] { 0, n - 1 })
			{
				for (int i = 0; i < m; i++)
				{
					original[i, j]++;
				}
			}

			int sum = 0;
			ints[startRow, startColumn] = 1;
			checked
			{
				for (int step = 0; step < maxMove; step++)
				{
					for (int i = 0; i < m; i++)
					{

						for (int j = 0; j < n; j++)
						{
							if (original[i, j] > 0)
							{
								sum = (sum + (ints[i, j] * original[i, j])% mod ) % mod;
							}
							if (i > 0)
								next[i, j] = (next[i, j] + ints[i - 1, j]) % mod;
							if (j > 0)
								next[i, j] = (next[i, j] + ints[i, j - 1]) % mod;
							if (i < m - 1)
								next[i, j] = (next[i, j] + ints[i + 1, j]) % mod;
							if (j < n - 1)
								next[i, j] = (next[i, j] + ints[i, j + 1]) % mod;
						}
					}
					ints = next;
					next = new int[m, n];
				}
			}
			return (int)(sum % mod);
		}
	}
}