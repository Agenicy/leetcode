using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q377
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.CombinationSum4(new[] { 1, 2, 3 }, 4));
			Log.Print(solution.CombinationSum4(new[] { 9 }, 3));
			Log.Print("The answer should be 7/ 0");
		}
	}
	public class Solution
	{
		public int CombinationSum4(int[] nums, int target)
		{
			Dictionary<int, int> dict = new();
			Array.Sort(nums, (a, b) => b.CompareTo(a));


			int Query(int sum)
			{
				if (sum == 0)
					return 1;
				else if (dict.ContainsKey(sum))
					return dict[sum];

				int res = 0;
				int temp;
				for (int i = 0; i < nums.Length; i++)
				{
					if ((temp = sum - nums[i]) >= 0)
						res += Query(temp);
				}
				dict[sum] = res;
				return res;
			}
			return Query(target);
		}
	}
}