using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q198
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.Rob(Parser.ParseArr1D("[2,7,9,3,1]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int Rob(int[] nums)
		{
			if (nums.Length < 2)
				return nums.Max();

			nums[2] += nums[0];
			for (int i = 3; i < nums.Length; i++)
			{
				nums[i] += Math.Max(nums[i - 3], nums[i - 2]);
			}
			return Math.Max(nums[nums.Length - 2], nums[nums.Length - 1]);
		}
	}
}