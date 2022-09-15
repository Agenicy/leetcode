using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q2007
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindOriginalArray(new[] { 0, 0 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[] FindOriginalArray(int[] changed)
		{
			Array.Sort(changed);
			Dictionary<int, int> set = new();
			foreach (var item in changed)
			{
				if (set.ContainsKey(item))
					set[item]++;
				else
					set[item] = 1;
			}

			List<int> ret = new(changed.Length / 2 + 1);

			for (int i = 0; i < changed.Length; i++)
			{
				int f = changed[i];
				if (set.ContainsKey(f))
				{
					if (--set[f] == 0)
						set.Remove(f);
					if (set.ContainsKey(f * 2) && set[f * 2] >= 0)
					{
						ret.Add(f);
						if (--set[f * 2] == 0)
							set.Remove(f * 2);
					}
					else return new int[0];
				}
			}
			return ret.ToArray();
		}
	}
}