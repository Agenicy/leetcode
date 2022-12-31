using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q980
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.UniquePathsIII(Parser.ParseArr2D("[[1,0,0,0],[0,0,0,0],[0,0,2,-1]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int UniquePathsIII(int[][] grid)
		{
			int totalLengths = 0;
			int start_x = 0, start_y = 0;
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[0].Length; j++)
				{
					switch (grid[i][j])
					{
						case 0:
							totalLengths++;
							break;
						case 1:
							(start_x, start_y) = (i, j);
							break;
						default:
							break;
					}
				}
			}
			int ret = 0;
			void DFS(int x, int y, int length)
			{
				foreach ((int i, int j) in new[] { (x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1) })
				{
					if (i < 0 | i >= grid.Length | j < 0 | j >= grid[0].Length) continue;

					switch (grid[i][j])
					{
						case 0:
							grid[i][j] = -1;
							DFS(i, j, length + 1);
							grid[i][j] = 0;
							break;
						case 2:
							if (length == totalLengths)
								ret++;
							break;
						default:
							break;
					}
				}

			}
			DFS(start_x, start_y, 0);
			return ret;
		}
	}
}