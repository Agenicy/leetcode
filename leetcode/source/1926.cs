using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1926
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			//Log.Print(solution.NearestExit(new char[][] { new char[] { '+', '+', '.', '+' }, new char[] { '.', '.', '.', '+' }, new char[] { '+', '+', '+', '.' } }, new[] { 1, 2 }));
			Log.Print(solution.NearestExit(new[]{
new[]{'+','.','+','+','+','+','+'},
new[]{'+','.','+','.','.','.','+'},
new[]{'+','.','+','.','+','.','+'},
new[]{'+','.','.','.','+','.','+'},
new[]{'+','+','+','+','+','.','+'}}, new[] { 0, 1 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int NearestExit(char[][] maze, int[] entrance)
		{
			int xm = maze.Length - 1;
			int ym = maze[0].Length - 1;
			IEnumerator<int[]> Next(int[] ind)
			{
				int x = ind[0];
				int y = ind[1];
				if (x > 0)
				{
					yield return new[] { x - 1, y };
				}
				else
					yield return new[] { 0 };
				if (x < xm)
				{
					yield return new[] { x + 1, y };
				}
				else
					yield return new[] { 0 };

				if (y > 0)
					yield return new[] { x, y - 1 };
				else
					yield return new[] { 0 };

				if (y < ym)
					yield return new[] { x, y + 1 };
				else
					yield return new[] { 0 };
			}
			Queue<int[]> BFS = new();
			BFS.Enqueue(entrance);
			BFS.Enqueue(null);
			int count = 0;
			while (BFS.Count > 1)
			{
				int[] next = BFS.Dequeue();
				maze[next[0]][next[1]] = '*';

				if (next == null)
				{
					count++;
					BFS.Enqueue(null);
					continue;
				}

				var ie = Next(next);
				while (ie.MoveNext())
				{
					if (ie.Current.Length == 1)
					{
						if (count > 0)
							return count;
						else
							continue;
					}
					int x = ie.Current[0];
					int y = ie.Current[1];
					if (maze[x][y] == '.')
					{
						BFS.Enqueue(ie.Current);
						maze[x][y] = '*';
					}
				}
			}
			return -1;
		}
	}
}