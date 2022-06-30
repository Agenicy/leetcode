using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q462
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MinMoves2(Parser.Parse("[203125577,-349566234,230332704,48321315,66379082,386516853,50986744,-250908656,-425653504,-212123143]")));
			Console.WriteLine(solution.MinMoves2(Parser.Parse("[1, 0, 0, 8, 6]")));
			Console.WriteLine(solution.MinMoves2(Parser.Parse("[1,2,3]")));
			Console.WriteLine(solution.MinMoves2(Parser.Parse("[1,10,2,9]")));
			Console.WriteLine("The answer should be 2127271182/ 14 / 2/ 16");
		}
	}
	public class Parser
	{
		public static int[] Parse(string input)
		{
			List<int> list = new List<int>();
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
		public int MinMoves2(int[] nums)
		{
			Array.Sort(nums);
			return nums.Sum(x => Math.Abs(x - nums[nums.Length / 2]));
		}
	}
}