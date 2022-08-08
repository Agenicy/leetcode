using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q300
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.LengthOfLIS(Parser.ParseArr1D("[3, 5, 6, 2, 5, 4, 19, 5, 6, 7, 12]")));
			Log.Print(solution.LengthOfLIS(Parser.ParseArr1D("[10,9,2,5,3,7,101,18]")));
			Log.Print(solution.LengthOfLIS(Parser.ParseArr1D("[0,1,0,3,2,3]")));
			Log.Print(solution.LengthOfLIS(Parser.ParseArr1D("[7,7,7,7,7,7,7]")));
			Log.Print("The answer should be 6/ 4/ 4/ 1");
		}
	}
	public class Solution
	{
		public int LengthOfLIS(int[] nums)
		{
			SortedList<int, int> sl = new(nums.Length);
			sl.Add(nums[0], 1);

			int maxL = 1;
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] > sl.Keys[sl.Count - 1])
					sl.Add(nums[i], ++maxL);

				int max = 0;
				for (int j = 0; j < sl.Count; j++)
				{
					if (sl.Keys[j] < nums[i])
					{
						max = Math.Max(max, sl.Values[j]);
					}
					else if (sl.Keys[j] == nums[i])
					{
						sl[nums[i]] = ++max;
						maxL = Math.Max(maxL, max);
						break;
					}

					if (j == sl.Count - 1 || sl.Keys[j] > nums[i])
					{
						sl.Add(nums[i], ++max);
						maxL = Math.Max(maxL, max);
						break;
					}
				}
			}
			return maxL;
		}
	}
}