using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q334
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
		public bool IncreasingTriplet(int[] nums)
		{
			if (nums.Length < 3)
				return false;

			int two = int.MaxValue;
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] <= nums[0])
					nums[0] = nums[i];
				else if (nums[i] <= two)
					two = nums[i];
				else
					return true;
			}
			return false;
		}
	}
}