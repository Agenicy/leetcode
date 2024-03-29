﻿using System;
using System.Collections.Generic;

namespace leetcode.Q376
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.WiggleMaxLength(Parser.ParseArr1D("[33,53,12,64,50,41,45,21,97,35,47,92,39,0,93,55,40,46,69,42,6,95,51,68,72,9,32,84,34,64,6,2,26,98,3,43,30,60,3,68,82,9,97,19,27,98,99,4,30,96,37,9,78,43,64,4,65,30,84,90,87,64,18,50,60,1,40,32,48,50,76,100,57,29,63,53,46,57,93,98,42,80,82,9,41,55,69,84,82,79,30,79,18,97,67,23,52,38,74,15]")));
			Console.WriteLine(solution.WiggleMaxLength(Parser.ParseArr1D("[3,3,3,2,5]")));
			Console.WriteLine(solution.WiggleMaxLength(Parser.ParseArr1D("[1,7,4,9,2,5]")));
			Console.WriteLine(solution.WiggleMaxLength(Parser.ParseArr1D("[1,17,5,10,13,15,10,5,16,8]")));
			Console.WriteLine(solution.WiggleMaxLength(Parser.ParseArr1D("[1,2,3,4,5,6,7,8,9]")));
			Console.WriteLine("The answer should be 67/ 3/ 6/ 7/ 2");
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
		public int WiggleMaxLength(int[] nums)
		{
			int max = 1;
			int record = nums[0];
			bool started = false;
			bool flip = true;
			for (int i = 1; i < nums.Length; i++)
			{
				if(!started)
					if(!(nums[i] == record))
					{
						started = true;
						flip = nums[i] > record;
					}
				if (flip && nums[i] > record || !flip && nums[i] < record)
				{
					flip = !flip;
					++max;
					record = nums[i];
				}
				else
				{
					if (flip)
						record = Math.Min(nums[i], record);
					else
						record = Math.Max(nums[i], record);
				}
			}
			return max;
		}
	}
}