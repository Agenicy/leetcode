using System;
using System.Collections.Generic;

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
			int center = QuickSelect(ref nums, nums.Length / 2);

			int sum = 0;
			checked
			{
				for (int i = 0; i < nums.Length; i++)
				{
					sum += Math.Abs(center - nums[i]);
					//int s = Math.Abs(center - nums[i]); ;
					//sum += s;
				}
			}
			return sum;
		}
		int QuickSelect(ref int[] list, int ind)
		{
			int x = list[list.Length - 1];
			int[] array = new int[list.Length];
			int a = 0, b = list.Length - 1;
			for (int i = 0; i < list.Length; i++)
			{
				if (list[i] > x)
					array[a++] = list[i];
				else
					array[b--] = list[i];
			}

			if (a == ind)
				return x;
			else
			{
				if (a > ind)
					return QuickSelect(ref array, 0, a, ind);
				else
					return QuickSelect(ref array, a, list.Length, ind);
			}
		}
		int QuickSelect(ref int[] list, int from, int end, int ind)
		{
			int x = list[end - 1];
			int[] array = new int[list.Length];
			int a = from, b = end - 1;
			for (int i = from; i < end; i++)
			{
				if (list[i] > x)
					array[a++] = list[i];
				else
					array[b--] = list[i];
			}
			if (a == ind)
				return x;
			else
			{
				if (a > ind)
					return QuickSelect(ref array, from, a, ind);
				else
					return QuickSelect(ref array, a + 1, end, ind);
			}
		}
	}
}