using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q48
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			var mat = Parser.ParseArr2D("[[1,2,3],[4,5,6],[7,8,9]]");
			solution.Rotate(mat);
			Log.Print(mat);
			mat = Parser.ParseArr2D("[[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]");
			solution.Rotate(mat);
			Log.Print(mat);
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public void Rotate(int[][] matrix)
		{
			int leftMax = (int)MathF.Floor(matrix.Length / 2.0f);

			int max = matrix.Length - 1;
			for (int i = 0; i < leftMax; i++)
			{
				for (int j = 0; j < matrix.Length - leftMax; j++)
					(matrix[i][j], matrix[j][max - i],
					 matrix[max - j][i], matrix[max - i][max - j]) =
					 (matrix[max - j][i], matrix[i][j],
					  matrix[max - i][max - j], matrix[j][max - i]);
			}
		}
	}
}