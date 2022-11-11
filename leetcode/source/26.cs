using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q26
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
		public int RemoveDuplicates(int[] nums)
		{
			int start = 0;
			for (int i = 1; i < nums.Length; i++)
			{
				while (i < nums.Length && nums[start] == nums[i])
				{ 
						++i;
				}
				if(i < nums.Length)
					nums[++start] = nums[i];
			}
			return start;
		}
	}
}