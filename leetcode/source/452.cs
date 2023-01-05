using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q452
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindMinArrowShots(Parser.ParseArr2D("[[10,16],[2,8],[1,6],[7,12]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int FindMinArrowShots(int[][] points)
		{
			int sum = 0;
			var ballons = points.OrderBy(p => p[1]).ToList();
			int id = 0;
			while (ballons.Count > id)
			{
				++sum;
				int arrow = ballons[id][1];
				while (ballons.Count > id && ballons[id][0] <= arrow)
				{
					id++;
				}
			}
			return sum;
		}
	}
}