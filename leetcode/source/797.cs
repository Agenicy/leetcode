using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q797
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.AllPathsSourceTarget(Parser.ParseArr2D("[[4,3,1],[3,2,4],[3],[4],[4]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
		{
			List<IList<int>> ret = new();
			int final = graph.Length - 1;
			void DFS(int i, List<int> list)
			{
				foreach (int n in graph[i])
				{
					if (n == final)
						ret.Add(new List<int>(list) { final });
					else
						DFS(n, new List<int>(list) { n });
				}

			}
			DFS(0, new() { 0 });
			return (IList<IList<int>>)ret;
		}
	}
}