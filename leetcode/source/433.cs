using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace leetcode.Q433
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MinMutation("AACCGGTT", "AACCGGTA", new[] { "AACCGGTA" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MinMutation(string start, string end, string[] bank)
		{
			if (!bank.Contains(end))
				return -1;

			bool Mutable(string a, string b)
			{
				int count = 0;
				for (int i = 0; i < a.Length; i++)
					if (a[i] != b[i]) count++;
				return count == 1;
			}
			Dictionary<string, HashSet<string>> pool = new();
			pool[start] = new(5);
			for (int i = 0; i < bank.Length; i++)
			{
				if (Mutable(start, bank[i]))
					pool[start].Add(bank[i]);

				if (!pool.ContainsKey(bank[i]))
					pool[bank[i]] = new(5);
				if (Mutable(end, bank[i]))
					pool[bank[i]].Add(end);

				for (int j = i + 1; j < bank.Length; j++)
				{
					if (Mutable(bank[i], bank[j]))
					{
						if (!pool.ContainsKey(bank[j]))
							pool[bank[j]] = new(5);

						pool[bank[i]].Add(bank[j]);
						pool[bank[j]].Add(bank[i]);
					}

				}
			}

			HashSet<string> hist = new();

			Queue<(string, int)> q = new();
			q.Enqueue((start, 1));

			while (q.Count > 0)
			{
				(string a, int i) = q.Dequeue();
				if (pool[a].Contains(end))
					return i;
				// else
				hist.Add(a);
				foreach (var s in pool[a])
				{
					if (!hist.Contains(s))
						q.Enqueue((s, i + 1));
				}
			}
			return -1;
		}
	}
}