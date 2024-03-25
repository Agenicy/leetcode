using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q442
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
		public IList<int> FindDuplicates(int[] nums)
		{
			IList<int> result = new List<int>();

			foreach (int num in nums)
			{
				int index = System.Math.Abs(num) - 1;
				if (nums[index] < 0)
				{
					result.Add(index + 1);
				}
				else
				{
					nums[index] = -nums[index];
				}
			}

			foreach (int num in nums)
			{
				int index = System.Math.Abs(num) - 1;
				nums[index] = -nums[index];
			}

			return result;
		}
	}
}