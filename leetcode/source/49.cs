using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q49
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
		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			Dictionary<int, List<string>> dict = new();
			foreach (var s in strs)
			{
				int[] h = new int[26];
				foreach (var c in s)
				{
					h[c - 'a']++;
				}
				int hash = h.Aggregate(0, (total, next) => HashCode.Combine(total, next));

				if (!dict.ContainsKey(hash))
					dict[hash] = new();
				dict[hash].Add(s);
			}
			List<IList<string>> ret = new();
			foreach (var set in dict)
			{
				ret.Add(set.Value);
			}
			return ret;
		}
	}
}