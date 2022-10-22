using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q76
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MinWindow("cabwefgewcwaefgcf", "cae"));
			Log.Print(solution.MinWindow("a", "aa"));
			Log.Print(solution.MinWindow("ADOBECODEBANC", "ABC"));
			Log.Print("The answer should be cwae/ / BANC");
		}
	}
	public class Solution
	{
		public string MinWindow(string s, string t)
		{
			Dictionary<char, int> match = new();
			Dictionary<char, Queue<int>> pool = new();
			int min = int.MaxValue, start = 0, end = -1;
			for (int i = 0; i < t.Length; i++)
			{
				if (!match.ContainsKey(t[i]))
					match[t[i]] = 1;
				else
					match[t[i]]++;
			}
			int count = match.Count;
			for (int i = 0; i < s.Length; i++)
			{
				if (match.ContainsKey(s[i]))
				{
					if (!pool.ContainsKey(s[i]))
						pool[s[i]] = new();

					if (pool[s[i]].Count == match[s[i]] - 1)
						count--;
					else if (pool[s[i]].Count > match[s[i]] - 1)
						pool[s[i]].Dequeue();

					pool[s[i]].Enqueue(i);
					if (count == 0)
					{
						int st = pool.Min(x => x.Value.Peek());
						if ((i - st) < min)
						{
							min = i - st;
							start = st;
							end = i;
						}
					}
				}
			}

			return s.Substring(start, end - start + 1);
		}
	}
}