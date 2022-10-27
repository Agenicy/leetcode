using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q835
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
		public int LargestOverlap(int[][] img1, int[][] img2)
		{
			int m = img1.Length, n = 3 * m - 2;
			int[][] grid = new int[n][];
			for (int i = 0; i < grid.Length; i++)
				grid[i] = new int[n];

			int res = 0;
			for (int i = 0; i < n - m + 1; i++)
			{
				for (int j = 0; j < n - m + 1; j++)
				{
					res = Math.Max(res, getOverlap(i, j, grid, img1, img2));
				}
			}
			return res;
		}

		private int getOverlap(int offsetX, int offsetY, int[][] grid, int[][] img1, int[][] img2)
		{
			int n = img1.Length;
			for (int i = n - 1; i < 2 * n - 1; i++)
			{
				for (int j = n - 1; j < 2 * n - 1; j++)
				{
					grid[i][j] = 0;
				}
			}

			for (int i = offsetX; i < offsetX + n; i++)
			{
				for (int j = offsetY; j < offsetY + n; j++)
				{
					grid[i][j] = img1[i - offsetX][j - offsetY];
				}
			}

			int res = 0;
			for (int i = n - 1; i < 2 * n - 1; i++)
			{
				for (int j = n - 1; j < 2 * n - 1; j++)
				{
					if (grid[i][j] == 1 && img2[i - (n - 1)][j - (n - 1)] == 1)
						res++;
				}
			}
			return res;
		}
	}
}