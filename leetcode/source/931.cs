using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q931
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
		public int MinFallingPathSum(int[][] matrix)
		{
			for (int i = matrix.Length - 2; i >= 0; i--)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					int below = matrix[i + 1][j];
					if (j > 0)
						below = Math.Min(below, matrix[i + 1][j - 1]);
					if (j < matrix[0].Length - 1)
						below = Math.Min(below, matrix[i + 1][j + 1]);
					matrix[i][j] += below;
				}
			}
			return matrix[0].Min();
		}
	}
}