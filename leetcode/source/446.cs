using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q446
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
		public class Solution
		{
			public int NumberOfArithmeticSlices(int[] nums)
			{
				int n = nums.Length;
				long ans = 0;
				var cnt = new Dictionary<int, int>[n];
				for (int i = 0; i < n; i++)
				{
					cnt[i] = new Dictionary<int, int>(i);
					for (int j = 0; j < i; j++)
					{
						long delta = (long)nums[i] - (long)nums[j];
						if (delta < int.MinValue || delta > int.MaxValue)
						{
							continue;
						}
						int diff = (int)delta;
						int sum = cnt[j].GetValueOrDefault(diff, 0);
						int origin = cnt[i].GetValueOrDefault(diff, 0);
						cnt[i][diff] = origin + sum + 1;
						ans += sum;
					}
				}
				return (int)ans;
			}
		}
	}
}