using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1443
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
		public int MinTime(int n, int[][] edges, IList<bool> hasApple)
		{
			Dictionary<int, HashSet<int>> map = new();
			void Add(int a, int b)
			{
				if(!map.ContainsKey(a))
					map[a] = new HashSet<int>();
				map[a].Add(b);
			}
			foreach (var e in edges)
			{
				Add(e[0], e[1]);
				Add(e[1], e[0]);
			}

			int depthNow = 0;
			int sum = 0;
			void DFS(int par, int depth)
			{
				if (!map.ContainsKey(par)) return;
				if (hasApple[par])
				{
					sum += Math.Abs(depth - depthNow);
					depthNow = depth;
				}
				var list = map[par];
				map.Remove(par);
				foreach (var child in list)
					DFS(child, depth + 1);
				depthNow = Math.Min(depthNow, depth - 1);
			}
			DFS(0, 0);
			return sum*2;
		}
	}
}