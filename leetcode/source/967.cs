using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q967
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.NumsSameConsecDiff(3, 7));
			Log.Print(solution.NumsSameConsecDiff(2, 1));
			Log.Print("The answer should be [181,292,707,818,929]/ [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]");
		}
	}
	public class Solution
	{
		public int[] NumsSameConsecDiff(int n, int k)
		{
			List<string> result = Enumerable.Range(1, 9).Select(x => x.ToString()).ToList();

			for (int i = 1; i < n; i++)
			{
				List<string> next = new();
				foreach (var item in result)
				{
					int last = item.Last()-'0';
					for (int t = 0; t <= 9; t++)
					{
						if (Math.Abs(last - t) == k)
							next.Add(item + t.ToString());
					}
				}
				result = next;
			}
			int[] ret = result.Select(x => int.Parse(x)).ToArray();
			return ret;
		}
	}
}