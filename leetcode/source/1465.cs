using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1465
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MaxArea(1000000000, 1000000000, Parser.ParseArr1D("[2]"), Parser.ParseArr1D("[2]")));
			Console.WriteLine(solution.MaxArea(5, 4, Parser.ParseArr1D("[3, 1]"), Parser.ParseArr1D("[1]")));
			Console.WriteLine(solution.MaxArea(5, 4, Parser.ParseArr1D("[3]"), Parser.ParseArr1D("[3]")));
			Console.WriteLine("The answer should be 81/ 6/ 9");
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
	}
	public class Solution
	{
		public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
		{
			Array.Sort(horizontalCuts);
			Array.Sort(verticalCuts);
			long maxH = horizontalCuts[0], maxW = verticalCuts[0];
			for (int i = 1; i < horizontalCuts.Length; i++)
			{
				maxH = Math.Max(maxH, horizontalCuts[i] - horizontalCuts[i - 1]);
			}
			for (int i = 1; i < verticalCuts.Length; i++)
			{
				maxW = Math.Max(maxW, verticalCuts[i] - verticalCuts[i - 1]);
			}
			maxH = Math.Max(maxH, h - horizontalCuts[horizontalCuts.Length - 1]);
			maxW = Math.Max(maxW, w - verticalCuts[verticalCuts.Length-1]);

			const int m = 1000000000 + 7;
			return (int)((maxH % m * maxW % m) % m);
		}
	}
}