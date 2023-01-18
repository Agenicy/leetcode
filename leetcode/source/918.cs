using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q918
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
		public int MaxSubarraySumCircular(int[] nums)
		{
			int sum = 0;
			int maxSum = int.MinValue;
			int minSum = int.MaxValue;
			int maxSumTemp = 0;
			int minSumTemp = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				sum += nums[i]; maxSumTemp += nums[i]; minSumTemp += nums[i];

				maxSum = Math.Max(maxSum, maxSumTemp);
				maxSumTemp = Math.Max(maxSumTemp, 0);

				minSum = Math.Min(minSum, minSumTemp);
				minSumTemp = Math.Min(minSumTemp, 0);
			}
			if (sum == minSum)
				return maxSum;
			else
				return Math.Max(maxSum, sum - minSum);
		}
	}
}