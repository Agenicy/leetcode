using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1329
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.DiagonalSort(Parser.ParseArr2D("[[37,98,82,45,42],[37,98,82,45,42]]")));

			Log.Print(solution.DiagonalSort(Parser.ParseArr2D("[[3,9],[2,4],[1,2],[9,8],[7,3]]")));

			Log.Print(solution.DiagonalSort(Parser.ParseArr2D("[[3,3,1,1],[2,2,1,2],[1,1,1,2]]")));
			Log.Print("The answer should be [[1,1,1,1],[1,2,2,2],[1,2,3,3]]");

			Log.Print(solution.DiagonalSort(Parser.ParseArr2D("[[11,25,66,1,69,7],[23,55,17,45,15,52],[75,31,36,44,58,8],[22,27,33,25,68,4],[84,28,14,11,5,50]]")));
			Log.Print("The answer should be \n" +
				"[[5,17,4,1,52,7],\n" +
				"[11,11,25,45,8,69],\n" +
				"[14,23,25,44,58,15],\n" +
				"[22,27,31,36,50,66],\n" +
				"[84,28,75,33,55,68]]");
		}
	}
	public class Solution
	{
		public int[][] DiagonalSort(int[][] mat)
		{
			if (mat.Length == 1 || mat[0].Length == 1)
				return mat;


			for (int i = 0; i < mat[0].Length - mat.Length + 1; i++)
			{
				int[] temp = Enumerable.Range(0, mat.Length).Select(x => mat[x][i + x]).OrderBy(x => x).ToArray();
				for (int x = 0; x < mat.Length; x++)
				{
					mat[x][i + x] = temp[x];
				}
			}
			for (int i = 1; i < mat.Length; i++)
			{
				int[] temp = Enumerable.Range(0, Math.Min(mat[0].Length, mat.Length - i)).Select(x => mat[x + i][x]).OrderBy(x => x).ToArray();
				for (int x = 0; x < temp.Length; x++)
				{
					mat[x + i][x] = temp[x];
				}
			}
			for (int i = 1; i < mat[0].Length; i++)
			{
				int[] temp = Enumerable.Range(0, Math.Min(mat.Length, i)).Select(x => mat[x][mat[0].Length - i + x]).OrderBy(x => x).ToArray();
				for (int x = 0; x < temp.Length; x++)
				{
					mat[x][mat[0].Length - i + x] = temp[x];
				}
			}
			return mat;
		}
	}
}