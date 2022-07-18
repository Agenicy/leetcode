using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1074
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.NumSubmatrixSumTarget(Parser.ParseArr2D("[[0,1,0],[1,1,1],[0,1,0]]"), 0));
			Console.WriteLine(solution.NumSubmatrixSumTarget(Parser.ParseArr2D("[[1,-1],[-1,1]]"), 0));
			Console.WriteLine(solution.NumSubmatrixSumTarget(Parser.ParseArr2D("[[904]]"), 0));
			Console.WriteLine("The answer should be 4/ 5/ 0");
		}
	}
	public class Parser
	{
		public static int[] ParseArr1D(string input)
		{
			System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
			input = input.Replace(" ", "").Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 1)
			{
				list.Add(int.Parse(array[i]));
			}
			return list.ToArray();
		}
		public static int[][] ParseArr2D(string input)
		{
			List<int[]> ret = new List<int[]>();
			input = input.Replace(" ", "");
			input = input.Substring(2, input.Length - 3);
			foreach (var s in input.Replace("],", "").Replace("]", "").Split("["))
			{
				string[] array = s.Split(',');
				var list = new List<int>(Enumerable.Range(0, array.Length).Select(x => int.Parse(array[x])));
				ret.Add(list.ToArray());
			}
			return ret.ToArray();
		}
	}
	public class Solution
	{
		public int NumSubmatrixSumTarget(int[][] matrix, int target)
		{
			int sum = 0;
			int[,] prefixSum = new int[matrix.Length + 1, matrix[0].Length + 1];
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					prefixSum[i + 1, j + 1] = matrix[i][j];
					if (i > 0)
						prefixSum[i + 1, j + 1] += prefixSum[i, j + 1];
					if (j > 0)
						prefixSum[i + 1, j + 1] += prefixSum[i + 1, j];
					if (i > 0 && j > 0)
						prefixSum[i + 1, j + 1] -= prefixSum[i, j];

				}
			}
			for (int h = 1; h < prefixSum.GetLength(0); h++)
			{
				for (int w = 1; w < prefixSum.GetLength(1); w++)
				{
					for (int i = 0; h + i < prefixSum.GetLength(0); i++)
					{
						for (int j = 0; w + j < prefixSum.GetLength(1); j++)
						{
							if (prefixSum[h + i, w + j] - prefixSum[i, w + j] - prefixSum[h + i, j] + prefixSum[i, j] == target)
							{
								//Console.WriteLine($"({i}, {j}, {h + i}, {w + j})");
								sum++;
							}
						}
					}
				}
			}
			return sum;
		}
	}
}