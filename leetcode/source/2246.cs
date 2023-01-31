using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;

namespace leetcode.Q2246
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
		public int LongestPath(int[] parent, string s)
		{
			Dictionary<int, List<int>> child = new();
			List<int> roots = new() { 0 };
			for (int i = 1; i < parent.Length; i++)
			{
				if (s[i] != s[parent[i]])
				{
					child.TryAdd(parent[i], new());
					child[parent[i]].Add(i);
				}
				else
				{
					roots.Add(i);
				}
			}
			int max = 1;
			int DFS(int par)
			{
				if (!child.ContainsKey(par))
					return 1;
				int m = 0, m1 = 0;
				for (int i = 0; i < child[par].Count; i++)
				{
					int len = DFS(child[par][i]);
					if (len > m)
					{
						m1 = m; m = len;
					}
					else if (len > m1)
					{
						m1 = len;
					}
				}
				max = Math.Max(max, m + m1 + 1);
				return m + 1;
			}
			foreach (var root in roots)
				DFS(root);
			return max;
		}
	}
}