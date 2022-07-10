using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.ToString());
			Console.WriteLine("The answer should be ");
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
	}
}