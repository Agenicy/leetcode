using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q907
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SumSubarrayMins(Parser.ParseArr1D("[3,1,2,4]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int SumSubarrayMins(int[] arr)
		{
			const int mod = (int)1e9 + 7;
			long count = 0;
			void Add(int input)
			{
				if (count > 1e9 | input > 1e9)
					count = (count + input) % mod;
				else
					count += input;
			}
			int[] dp = new int[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				dp[i] = arr[i];
				int j = i - 1;
				for (; j >= 0 && arr[i] <= arr[j]; j--) { }
				dp[i] = arr[i] * (i - j);
				if (j >= 0)
					dp[i] += dp[j];
				Add(dp[i]);
			}
			return (int)count;
		}
	}
}