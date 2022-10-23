using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q645
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindErrorNums(new[] { 3, 2, 2 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[] FindErrorNums(int[] nums)
		{
			int i = 0;
			while (i < nums.Length)
			{
				if (nums[i] == nums[nums[i] - 1])
					++i;
				else
					(nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
			}
			for (i = 0; i < nums.Length; i++)
			{
				if (nums[i] != i + 1)
					return new[] { nums[i], i + 1 };
			}
			return null;
		}
	}
}