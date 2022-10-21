using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q219
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
		public bool ContainsNearbyDuplicate(int[] nums, int k)
		{
			Dictionary<int, int> pool = new();
			for (int i = 0; i < nums.Length; i++)
			{
				int last;
				if (pool.TryGetValue(nums[i], out last))
				{
					if(i - last <= k)
						return true;
				}
				pool[nums[i]] = i;
			}
			return false;
		}
	}
}