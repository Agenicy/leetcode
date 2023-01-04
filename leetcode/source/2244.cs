using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace leetcode.Q2244
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
		public int MinimumRounds(int[] tasks)
		{
			Dictionary<int, int> ts = new();
			for (int i = 0; i < tasks.Length; i++)
			{
				if (!ts.ContainsKey(tasks[i]))
					ts.Add(tasks[i], 0);
				ts[tasks[i]]++;
			}
			int sum = 0;
			foreach (var t in ts)
			{
				if (t.Value < 2)
					return -1;
				else
				{
					sum += (t.Value / 3) + ((t.Value % 3) > 0 ? 1 : 0);
				}
			}
			return sum;
		}
	}
}