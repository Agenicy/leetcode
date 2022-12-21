using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q886
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.PossibleBipartition(5, Parser.ParseArr2D("[[1,2],[1,3],[1,4],[1,5]]")));
			Log.Print(solution.PossibleBipartition(5, Parser.ParseArr2D("[[1, 2],[2, 3],[3, 4],[4, 5],[1, 5]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool PossibleBipartition(int n, int[][] dislikes)
		{
			if (dislikes.Length == 0) return true;
			Dictionary<int, HashSet<int>> graph = new();
			void Add(int a, int b)
			{
				if (!graph.ContainsKey(a)) graph[a] = new HashSet<int>();
				graph[a].Add(b);
			}
			foreach (var item in dislikes)
			{
				Add(item[0], item[1]);
				Add(item[1], item[0]);
			}

			int[] color = new int[n + 1];
			Queue<int> queue = new Queue<int>();
			while (graph.Count > 0)
			{
				queue.Enqueue(graph.First().Key);
				while (queue.Count > 0)
				{
					int next = queue.Dequeue();
					if (color[next] == 0)
						color[next] = 1;
					foreach (var i in graph[next])
					{
						if (color[i] == color[next])
							return false;
						if (color[i] == 0)
						{
							queue.Enqueue(i);
							color[i] = -1 * color[next];
						}
					}
					graph.Remove(next);
				}
			}
			return true;
		}
	}
}