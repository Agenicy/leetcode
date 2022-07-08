using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1473
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MinCost(
				Parser.ParseArr1D("[2,3,0]"),
				Parser.ParseArr2D("[[5, 2, 3],[3, 4, 1],[1, 2, 1]]"), 3, 3, 3));

			Console.WriteLine(solution.MinCost(
				Parser.ParseArr1D("[0,0,0,0,0]"),
				Parser.ParseArr2D("[[1,10],[10,1],[10,1],[1,10],[5,1]]"), 5, 2, 3));
			Console.WriteLine(solution.MinCost(
				Parser.ParseArr1D("[0,2,1,2,0]"),
				Parser.ParseArr2D("[[1,10],[10,1],[10,1],[1,10],[5,1]]"), 5, 2, 3));
			Console.WriteLine(solution.MinCost(
				Parser.ParseArr1D("[3,1,2,3]"),
				Parser.ParseArr2D("[[1,1,1],[1,1,1],[1,1,1],[1,1,1]]"), 4, 3, 3));
			Console.WriteLine("The answer should be 1/ 9/ 11/ -1");
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
		public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
		{
			/// houses[i]: is the color of the house i, and 0 if the house is not painted yet.
			/// cost[i][j]: is the cost of paint the house i with the color j + 1.
			/// 
			/// Define dp[i][j][k] as the minimum cost 
			/// where we have k neighborhoods in the first i houses and the i-th house is painted with the color j.

			/* MinCost(house[0]=0) = Min(MinCost(house[0]=1), MinCost(house[0]=2))
			 */

			int[,,] dp = new int[m, n, target];

			for (int j = 0; j < n; j++)
			{
				dp[0, j, 0] = houses[0] == 0 ? cost[0][j] : houses[0] - 1 == j ? 0 : int.MaxValue;
				for (int k = 1; k < target; k++)
				{
					dp[0, j, k] = int.MaxValue;
				}
			}

			for (int i = 1; i < m; i++)
			{
				void DefineOneColor(int j, bool add)
				{
					for (int k = 0; k < target; k++)
					{
						// keep the same color
						dp[i, j, k] = (dp[i - 1, j, k] == int.MaxValue) ? int.MaxValue : add ? dp[i - 1, j, k] + cost[i][j] : dp[i - 1, j, k];

						if (k > 0)
						{
							int oldMinWithDiffColor = Enumerable.Range(0, n).Where(x => x != j).Min(x => dp[i - 1, x, k - 1]);
							int oldMin = (oldMinWithDiffColor == int.MaxValue) ? int.MaxValue : add ? oldMinWithDiffColor + cost[i][j] : oldMinWithDiffColor;
							// different color
							dp[i, j, k] = Math.Min(oldMin, dp[i, j, k]);
						}
					}
				}

				for (int l = 0; l < n; l++)
				{
					if (houses[i] == 0 || l == houses[i] - 1)
						DefineOneColor(l, houses[i] == 0);
					else
					{
						for (int k = 0; k < target; k++)
						{
							dp[i, l, k] = int.MaxValue;
						}
					}
				}
			}
			int ans = Enumerable.Range(0, n).Min(x => dp[m - 1, x, target - 1]);
			if (ans == int.MaxValue)
				return -1;
			else return ans;
		}
	}
}