using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1519
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
		public int[] CountSubTrees(int n, int[][] edges, string labels)
		{
			int[] ret = new int[n];


			Dictionary<int, HashSet<int>> map = new();
			void Add(int a, int b)
			{
				if (!map.ContainsKey(a))
					map[a] = new HashSet<int>();
				map[a].Add(b);
			}
			foreach (var e in edges)
			{
				Add(e[0], e[1]);
				Add(e[1], e[0]);
			}

			HashSet<int> check = new();
			void DFS(int par, Dictionary<char, int> rec)
			{
				if (check.Contains(par)) return;
				check.Add(par);
				List<Dictionary<char, int>> ms = new();
				foreach (var child in map[par])
				{
					Dictionary<char, int> n = new();
					ms.Add(n);
					DFS(child, n);
				}
				foreach (var d in ms)
				{
					foreach (var k in d.Keys)
					{

						if (rec.ContainsKey(k))
						{
							rec[k] += d[k];
						}
						else
						{
							rec[k] = d[k];
						}
					}
				}
				rec.TryAdd(labels[par], 0);
				rec[labels[par]] += 1;
				ret[par] = rec[labels[par]];
			}
			DFS(0, new());
			return ret;
		}
	}
}