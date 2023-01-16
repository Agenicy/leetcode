using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q57
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
		public int[][] Insert(int[][] intervals, int[] newInterval)
		{
			List<int[]> ret = new();
			if (intervals.Length == 0)
				return new[] { newInterval };
			else if (intervals[intervals.Length - 1][1] < newInterval[0])
			{
				ret = intervals.ToList();
				ret.Add(newInterval);
				return ret.ToArray();
			}
			else if (intervals[0][0] > newInterval[1])
			{
				ret = new() { newInterval };
				ret.AddRange(intervals);
				return ret.ToArray();
			}

			for (int i = 0; i < intervals.Length; i++)
			{
				if (intervals[i][1] < newInterval[0])
				{
					ret.Add(intervals[i]);
				}
				else if (intervals[i][0] > newInterval[1])
				{
					if (newInterval[1] != int.MinValue)
					{
						ret.Add(newInterval);
						newInterval = new[] { int.MaxValue, int.MinValue };
					}
					ret.Add(intervals[i]);
				}
				else
				{
					newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
					newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
				}
			}
			if (newInterval[1] != int.MinValue)
				ret.Add(newInterval);

			return ret.ToArray();
		}
	}
}