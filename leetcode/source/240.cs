using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q240
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SearchMatrix(Parser.ParseArr2D("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]"), 5));
			Log.Print(solution.SearchMatrix(Parser.ParseArr2D("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]"), 20));
			Log.Print("The answer should be true/ false");
		}
	}
	public class Solution
	{
		public bool SearchMatrix(int[][] matrix, int target)
		{
			bool Find(int[] x)
			{
				for (int i = 0; i < x.Length; i++)
				{
					if (x[i] > target) return false;
					else if (x[i] == target) return true;
				}
				return false;
			}
			return matrix.Any(x => Find(x));
		}
	}
}