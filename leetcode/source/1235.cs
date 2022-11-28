using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1235
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.JobScheduling(new[] { 1, 2, 3, 3 }, new[] { 3, 4, 5, 6 }, new[] { 50, 10, 40, 70 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
		{
			int nowTime = 0;
			int maxProfit = 0;
			List<(int, int, int)> values = new();

			for (int i = 0; i < startTime.Length; i++)
			{
				values.Add((startTime[i], endTime[i], profit[i]));
			}
			values.Sort();
			PriorityQueue<(int, int), int> future = new();
			for (int i = 0; i < values.Count; i++)
			{
				(int nextStart, int nextEnd, int prof) = values[i];
				while (future.Count > 0 && future.Peek().Item2 <= nextStart)
				{
					(int nv, int nt) = future.Dequeue();
					nowTime = nt;
					maxProfit = Math.Max(maxProfit, nv);
				}
				future.Enqueue((maxProfit + prof, nextEnd), nextEnd);

			}
			while (future.Count > 0)
			{
				(int nv, int nt) = future.Dequeue();
				maxProfit = Math.Max(maxProfit, nv);
			}
			return maxProfit;
		}
	}
}