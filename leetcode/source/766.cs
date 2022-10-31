using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q766
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
		public bool IsToeplitzMatrix(int[][] matrix)
		{
			for (int i = 0; i < matrix.Length-1; i++)
			{
				for (int j = 0; j < matrix[0].Length-1; j++)
				{
					if (matrix[i][j] != matrix[i + 1][j + 1])
						return false;
				}
			}
			return true;
		}
	}
}