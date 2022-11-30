using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1207
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
		public bool UniqueOccurrences(int[] arr)
		{
			Dictionary<int, int> stat = new();
			foreach (var item in arr)
			{
				if (!stat.ContainsKey(item))
					stat[item] = 1;
				else
					stat[item]++;
			}
			return new HashSet<int>(stat.Values).Count == stat.Values.Count;
		}
	}
}