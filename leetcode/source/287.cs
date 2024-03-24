using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q287
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindDuplicate(new[] {1, 3, 4, 2, 2}));
			Log.Print("The answer should be 2");
			Log.Print(solution.FindDuplicate(new[] {1, 4, 4, 2, 4}));
			Log.Print("The answer should be 4");
			Log.Print(solution.FindDuplicate(new[] {3, 3, 3, 3, 3, 3}));
			Log.Print("The answer should be 3");
		}
	}
	public class Solution
	{
		public int FindDuplicate(int[] nums)
		{
			BitArray bitArray = new BitArray(100000);
			for (int i = 0; i < nums.Length; i++)
			{
				if (bitArray[nums[i]-1] == true) return nums[i];

				bitArray[nums[i]-1] = true;
			}
			return nums[0];
		}
	}
}