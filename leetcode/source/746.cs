using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q746
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MinCostClimbingStairs(Parser.ParseArr1D("[10,15,20]")));
			Console.WriteLine(solution.MinCostClimbingStairs(Parser.ParseArr1D("[1,100,1,1,1,100,1,1,100,1]")));
			Console.WriteLine("The answer should be 15/ 6");
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
			//[[100,200],[200,1300],[1000,1250],[2000,3200]]
			List<int[]> ret = new List<int[]>();
			input = input.Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 2)
			{
				ret.Add(new int[] { int.Parse(array[i]), int.Parse(array[i + 1]) });
			}
			return ret.ToArray();
		}
	}
	public class Solution
	{
		public int MinCostClimbingStairs(int[] cost)
		{
			for (int i = 2; i < cost.Length; i++)
			{
				cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
			}
			return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
		}
	}
}