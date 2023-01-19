using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q974
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SubarraysDivByK(Parser.ParseArr1D("[7,4,-10]"), 5));
			Log.Print(solution.SubarraysDivByK(Parser.ParseArr1D("[4,5,0,-2,-3,1]"), 5));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int SubarraysDivByK(int[] nums, int k)
		{
			int preSum = 0;
			int[] countSort = new int[k];
			countSort[0] = 1;
			int sum = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				preSum = (nums[i] % k + preSum + k) % k;
				sum += countSort[preSum]++;
			}

			return sum;
		}
	}
}