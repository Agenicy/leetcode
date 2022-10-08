using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q16
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
		public int ThreeSumClosest(int[] nums, int target)
		{
			Array.Sort(nums);
			int closet = nums[0] + nums[1] + nums[2];
			for (int i = 0; i < nums.Length; i++)
			{
				int j = i + 1;
				int k = nums.Length - 1;
				while (j < k)
				{
					int res = nums[i] + nums[j] + nums[k];
					if (Math.Abs(res - target) < Math.Abs(closet - target))
					{
						closet = res;
					}
					if (res > target)
						k--;
					else
						j++;
				}
			}
			return closet;
		}
	}
}