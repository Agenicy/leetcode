using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1706
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindBall(Parser.ParseArr2D("[[1,1,1,-1,-1],[1,1,1,-1,-1],[-1,-1,-1,1,1],[1,1,1,1,-1],[-1,-1,-1,-1,-1]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[] FindBall(int[][] grid)
		{
			int width = grid[0].Length;
			int height = grid.Length;

			int[] result = Enumerable.Range(1, width).ToArray();

			for (int i = 0; i < height; i++)
			{
				int[] next = new int[width];
				for (int j = 0; j < width; j++)
				{
					if (grid[i][j] == 1 && j < width - 1 && grid[i][j + 1] == 1)
						next[j + 1] = result[j];
					else if (grid[i][j] == -1 && j > 0 && grid[i][j - 1] == -1)
						next[j - 1] = result[j];
				}
				result = next;
			}

			int[] ret = Enumerable.Repeat(-1, grid[0].Length).ToArray();
			for (int i = 0; i < result.Length; i++)
			{
				if (result[i] != 0)
					ret[result[i]-1] = i;
			}
			return ret;
		}
	}
}