using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q55
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
		public bool CanJump(int[] nums)
		{
			if (nums[0] == 0)
				return nums.Length == 1;
			for (int i = 0; i < nums.Length-1; i++)
			{
				if (nums[i] == 0)
				{
					if (Enumerable.Range(1, i).All(j => nums[i - j] <= j))
						return false;
				}
			}
			return true;
		}
	}
}