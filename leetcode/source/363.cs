using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q363
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MaxSumSubmatrix(Parser.ParseArr2D("[[2,2,-1]]"), 0));
			Log.Print(solution.MaxSumSubmatrix(Parser.ParseArr2D("[[5,-4,-3,4],[-3,-4,4,5],[5,1,5,-4]]"), 3));
			Log.Print(solution.MaxSumSubmatrix(Parser.ParseArr2D("[[1, 0, 1],[0, -2, 3]]"), 2));
			Log.Print("The answer should be -1/2/2");
		}
	}
	public class Solution
	{
		public int MaxSumSubmatrix(int[][] matrix, int k)
		{
			int[,] presum = new int[matrix.Length + 1, matrix[0].Length + 1];
			int max = int.MinValue;
			for (int i = 1; i < matrix.Length + 1; i++)
			{
				for (int j = 1; j < matrix[0].Length + 1; j++)
				{
					presum[i, j] = -presum[i - 1, j -1] + presum[i - 1, j] + presum[i, j - 1] + matrix[i-1][j-1];
					if (presum[i, j] == k)
						return k;
					for (int x = 0; x < i; x++)
					{
						for (int y = 0; y < j; y++)
						{
							if (x == i && y == j)
								continue;
							int res = presum[i, j] + presum[x, y] - presum[i, y] - presum[x, j];
							if (res == k)
								return k;
							else if (res < k)
								max = Math.Max(max, res);
						}
					}
				}
			}
			return max;
		}
	}
}