using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q417
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Log.Print(solution.PacificAtlantic(Parser.ParseArr2D("[[1,1],[1,1],[1,1]]")));

			Log.Print(solution.PacificAtlantic(Parser.ParseArr2D("[[1, 2, 3],[8, 9, 4],[7, 6, 5]]")));
			Log.Print("The answer should be [[0,2],[1,0],[1,1],[1,2],[2,0],[2,1],[2,2]]");

			Log.Print(solution.PacificAtlantic(Parser.ParseArr2D("[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]")));
			Log.Print("The answer should be [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]");
		}
	}
	public class Solution
	{
		public IList<IList<int>> PacificAtlantic(int[][] heights)
		{
			int m = heights.Length;
			int n = heights[0].Length;
			bool[,] P = new bool[m, n];
			bool[,] A = new bool[m, n];

			List<(int, int)> FourDirection(int x, int y)
			{
				return new List<(int, int)>(
					(Enumerable.Range(x - 1, 3).Where(i => i != x && i >= 0 && i < m).Select(i => (i, y))).Union(
					Enumerable.Range(y - 1, 3).Where(i => i != y && i >= 0 && i < n).Select(i => (x, i))));
			}

			List<(int, int)> now = new(Enumerable.Range(0, m).Select(x => (x, 0)).Union(
										Enumerable.Range(0, n).Select(x => (0, x))));


			foreach ((int x, int y) in now)
				P[x, y] = true;

			while (now.Count > 0)
			{
				List<(int, int)> next = new();
				foreach ((int x, int y) in now)
				{
					var dir = FourDirection(x, y);
					foreach ((int i, int j) in dir)
					{
						if (!P[i, j] && heights[i][j] >= heights[x][y])
						{
							P[i, j] = true;
							next.Add((i, j));
						}
					}
				}
				now = next;
			}

			now = new(Enumerable.Range(0, m).Select(x => (x, n-1)).Union(
										Enumerable.Range(0, n).Select(x => (m-1, x))));


			foreach ((int x, int y) in now)
				A[x, y] = true;

			while (now.Count > 0)
			{
				List<(int, int)> next = new();
				foreach ((int x, int y) in now)
				{
					var dir = FourDirection(x, y);
					foreach ((int i, int j) in dir)
					{
						if (!A[i, j] && heights[i][j] >= heights[x][y])
						{
							A[i, j] = true;
							next.Add((i, j));
						}
					}
				}
				now = next;
			}


			List<IList<int>> res = new();

			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (P[i, j] && A[i, j])
						res.Add(new List<int>() { i, j });
				}
			}
			return res;
		}
	}
}