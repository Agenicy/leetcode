using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q976
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int LargestPerimeter(int[] nums)
		{
			Array.Sort(nums, (a, b)=>b.CompareTo(a));
			for (int i = 0; i < nums.Length; i++)
			{
				if (i > nums.Length - 2) return 0;

				if (nums[i] < nums[i + 1] + nums[i + 2])
					return (nums[i] + nums[i + 1] + nums[i + 2]);
			}
			return 0;
		}
	}
}