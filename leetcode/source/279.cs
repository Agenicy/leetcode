using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q279
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
		public int NumSquares(int n)
		{
			Queue<(int, int)> q = new();
			q.Enqueue((n, 1));
			while (q.Count > 0)
			{
				(int m, int count) = q.Dequeue();
				int sqrt = 1;
				int sq;
				do
				{
					sq = sqrt * sqrt;
					if (m == sq)
						return count;
					else
					{
						q.Enqueue((m - sq, count + 1));
					}
					++sqrt;
				}
				while (sq <= m);
			}
			return n;
		}
	}
}