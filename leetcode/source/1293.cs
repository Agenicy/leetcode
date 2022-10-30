using leetcode.Q429;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace leetcode.Q1293
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
		public int ShortestPath(int[][] grid, int k)
		{
			int m = grid.Length, n = grid[0].Length;
			if (k > (m - 1 + n - 1))
			{
				return m - 1 + n - 1;
			}
			var q = new Queue<(int, int, int, int)>(); // i, j, distance, remaining steps to break 1
			var seen = new HashSet<(int, int, int)>();  // i, j, remaining steps to break 1
			q.Enqueue((0, 0, 0, k));
			seen.Add((0, 0, k));

			int res = -1;

			while (q.Count > 0)
			{
				var (i, j, dist, steps) = q.Dequeue();
				if (i == m - 1 && j == n - 1)
				{
					if (res == -1 || dist < res)
					{
						res = dist;
					}
				}
				foreach (var (di, dj) in new List<(int, int)> { (0, -1), (0, 1), (-1, 0), (1, 0) })
				{
					int ni = i + di, nj = j + dj;
					if (ni >= 0 && ni < grid.Length && nj >= 0 && nj < grid[0].Length)
					{
						if (grid[ni][nj] == 0 && !seen.Contains((ni, nj, steps)))
						{
							q.Enqueue((ni, nj, dist + 1, steps));
							seen.Add((ni, nj, steps));
						}
						if (grid[ni][nj] == 1 && steps > 0 && !seen.Contains((ni, nj, steps - 1)))
						{
							q.Enqueue((ni, nj, dist + 1, steps - 1));
							seen.Add((ni, nj, steps - 1));
						}
					}
				}
			}

			return res;
		}
	}
}