using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q523
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.CheckSubarraySum(Parser.ParseArr1D("[5, 0, 0, 0]"), 3));
			Log.Print(solution.CheckSubarraySum(Parser.ParseArr1D("[1, 0]"), 2));
			Log.Print(solution.CheckSubarraySum(Parser.ParseArr1D("[23, 6, 9]"), 6));
			Log.Print(solution.CheckSubarraySum(Parser.ParseArr1D("[23,2,4,6,6]"), 7));
			Log.Print(solution.CheckSubarraySum(Parser.ParseArr1D("[23,2,4,6,7]"), 6));
			Log.Print(solution.CheckSubarraySum(Parser.ParseArr1D("[23,2,6,4,7]"), 13));
			Log.Print("The answer should be T/ F/ F/ T/ T/ F");
		}
	}
	public class Solution
	{
		public bool CheckSubarraySum(int[] nums, int k)
		{
			int sum = 0;
			Dictionary<int, int> dict = new();
			dict[0] = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				sum += nums[i];
				if (!dict.ContainsKey(sum % k))
				{
					dict[sum % k] = i + 1;
				}
				else if (dict[sum % k] < i)
					return true;

			}
			return false;
		}
	}
}