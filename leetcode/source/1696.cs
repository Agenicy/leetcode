﻿using System;
using System.Collections.Generic;

namespace leetcode.Q1696
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
		public int MaxResult(int[] nums, int k)
		{
			PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
			for (int i = 0; i < nums.Length - 1; ++i)
			{
				pq.Enqueue(i, -nums[i]);
				while (pq.Peek() < i - k + 1)
					pq.Dequeue();
				nums[i + 1] += nums[pq.Peek()];
			}
			return nums[nums.Length - 1];
		}
	}
}