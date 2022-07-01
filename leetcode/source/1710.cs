using System;
using System.Collections.Generic;

namespace leetcode.Q1710
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MaximumUnits(Parser.Parse("[[1,3],[5,5],[2,5],[4,2],[4,1],[3,1],[2,2],[1,3],[2,5],[3,2]]"),35));
			Console.WriteLine(solution.MaximumUnits(Parser.Parse("[[1,3],[2,2],[3,1]]"),4));
			Console.WriteLine(solution.MaximumUnits(Parser.Parse("[[5,10],[2,5],[4,7],[3,9]]"),10));
			Console.WriteLine("The answer should be 76/ 8/ 91");
		}
	}

	public class Parser
	{
		public static int[][] Parse(string input)
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
		public int MaximumUnits(int[][] boxTypes, int truckSize)
		{
			Array.Sort(boxTypes, (x, y)=> y[1].CompareTo(x[1]));
			int sum = 0;
			for (int size = 0, i = 0; size < truckSize && i < boxTypes.Length; i++)
			{
				var box = boxTypes[i];
				int next = Math.Min(truckSize - size, box[0]);
				sum += box[1] * next;
				size += next;
			}
			return sum;
		}
	}
}