using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1971
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
		public bool ValidPath(int n, int[][] edges, int source, int destination)
		{
			if (edges.Length == 0)
				return source == destination;
			Queue<int> queue = new Queue<int>();
			Dictionary<int, List<int>> graph = new();
			for (int i = 0; i < edges.Length; i++)
			{
				int a = edges[i][0];
				int b = edges[i][1];
				if(!graph.ContainsKey(a))
					graph[a] = new List<int>();
				graph[a].Add(b);
				if (!graph.ContainsKey(b))
					graph[b] = new List<int>();
				graph[b].Add(a);
			}
			foreach (var item in graph[source])
			{
				queue.Enqueue(item);
			}
			while(queue.Count > 0)
			{
				int a = queue.Dequeue();
				if (a == destination)
					return true;
				if(graph.ContainsKey(a))
				{
					foreach (var item in graph[a])
					{
						queue.Enqueue(item);
					}
					graph.Remove(a);
				}
			}
			return false;
		}
	}
}