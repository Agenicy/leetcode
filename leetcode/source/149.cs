using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q149
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
		public int MaxPoints(int[][] points)
		{
			int max = 0;

			for (int i = 0; i < points.Length; i++)
			{
				Dictionary<float, int> ms = new();
				for (int j = 0; j < points.Length; j++)
				{
					if (i == j) continue;
					float mIJ = m(i, j);
					if (!ms.ContainsKey(mIJ))
						ms[mIJ] = 1;
					else
						ms[mIJ]++;

					max = Math.Max(max, ms.Max(x => x.Value)+1);
				}
			}

			float m(int i, int j)
			{
				if (points[i][0] != points[j][0])
					return (points[i][1] - points[j][1]) / (float)(points[i][0] - points[j][0]);
				else return int.MaxValue;
			}
			return max;
		}
	}
}