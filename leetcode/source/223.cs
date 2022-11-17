using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q223
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
		public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
		{
			int Relu(int x) => x > 0 ? x : 0;
			int cover = Relu(Math.Min(ax2, bx2) - Math.Max(ax1, bx1)) * Relu(Math.Min(ay2, by2) - Math.Max(ay1, by1));
			return (ax2 - ax1) * (ay2 - ay1) + (bx2 - bx1) * (by2 - by1) - cover;
		}
	}
}