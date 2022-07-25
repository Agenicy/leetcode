using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q34
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SearchRange(Parser.ParseArr1D("[5,7,7,8,8,10]"), 6));
			Log.Print(solution.SearchRange(Parser.ParseArr1D("[5,7,7,8,8,10]"), 8));
			Log.Print("The answer should be [-1, -1]/ [3, 4]");
		}
	}
	public class Solution
	{
		public int[] SearchRange(int[] nums, int target)
		{
			if (nums.Length == 0) return new[] { -1, -1 };

			int left = 0, right = nums.Length - 1;
			while (left + 1 < right)
			{
				int now = (left + right) / 2;
				if (nums[now] > target) right = now;
				else if (nums[now] < target) left = now;
				else
				{
					for (int i = now; i <= right; i++)
					{
						if (nums[i] != target)
						{
							right = i - 1;
							break;
						}
					}
					for (int i = now; i >= left; i--)
					{
						if (nums[i] != target)
						{
							left = i + 1;
							break;
						}
					}
					return new[] { left, right };
				};
			}
			if (nums[left] == target && nums[right] == target)
				return new[] { left, right };
			else if (nums[left] == target)
				return new[] { left, left };
			else if (nums[right] == target)
				return new[] { right, right };
			return new[] { -1, -1 };
		}
	}
}