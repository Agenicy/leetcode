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
			HashSet<int> set = new();
			Dictionary<int, int> dict = new();
			foreach (int num in nums)
			{
				if (!dict.ContainsKey(num))
					dict[num] = 1;
				else if (dict[num] < 3)
				{
					dict[num]++;

					if (dict[num] == 2)
						set.Add(num);
					else if (dict[num] == 3)
						set.Remove(num);
				}
			}
			return set.ToList();
		}
	}
}