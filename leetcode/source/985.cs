using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace leetcode.Q985
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SumEvenAfterQueries(Parser.ParseArr1D("[1,2,3,4]"), Parser.ParseArr2D("[[1,0],[-3,1],[-4,0],[2,3]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
		{
			int sum = 0;
			int[] result = new int[queries.Length];
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] % 2 == 0)
					sum += nums[i];
			}
			for (int i = 0; i < queries.Length; i++)
			{
				int place = queries[i][1];
				int val = queries[i][0];

				if (nums[place] % 2 == 0)
					sum -= nums[place];

				nums[place] += val;

				if (nums[place] % 2 == 0)
					sum += nums[place];

				result[i] = sum;
			}
			return result;
		}
	}
}