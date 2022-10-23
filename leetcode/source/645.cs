using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q645
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindErrorNums(new[] { 3, 2, 2 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[] FindErrorNums(int[] nums)
		{
			return new[]
			{
				nums.GroupBy(x => x)
					.Where(x => x.Count() == 2)
					.Select(x => x.Key)
					.First(),
				Enumerable.Range(1, nums.Length).Except(nums).First()
			};
		}
	}
}