#define Debug
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace leetcode.Q834
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SumOfDistancesInTree(6, Parser.ParseArr2D("[[0,1],[0,2],[2,3],[2,4],[2,5]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		class Node
		{
#if Debug
			static int ID = 0;
			int id = ID++;
#endif
			public static Dictionary<Node, List<Node>> Nodes = new();
			Dictionary<Node, (int, int)> hist = new();

			public void GetDist(Node par, ref int dist, ref int node)
			{
				if (par != null && hist.ContainsKey(par))
				{
					dist += hist[par].Item1;
					node += hist[par].Item2;
					return;
				}

				if (Nodes[this].Count == 1 & par != null)
				{
					dist += 1;
					node += 1;
				}
				else
				{
					int sumP = 0, sumN = 0;
					foreach (var item in Nodes[this])
					{
						if (item != par)
							item.GetDist(this, ref sumP, ref sumN);
					}

					if (par != null)
					{
						dist += sumP + 1 + sumN;
						node += sumN + 1;
						hist[par] = (sumP + 1 + sumN, sumN + 1);
					}
					else
					{
						dist = sumP;
					}
				}
			}
		}

		public int[] SumOfDistancesInTree(int n, int[][] edges)
		{
			if (n <= 1) return new[] { 0 };
			Node[] nodes = new Node[n];
			for (int i = 0; i < n; i++)
				nodes[i] = new Node();
			void Add(int a, int b)
			{
				if (!Node.Nodes.ContainsKey(nodes[a]))
					Node.Nodes[nodes[a]] = new();
				Node.Nodes[nodes[a]].Add(nodes[b]);
			}

			foreach (var item in edges)
			{
				Add(item[0], item[1]);
				Add(item[1], item[0]);
			}

			int[] ret = new int[n];
			for (int i = 0; i < n; i++)
			{
				int node = 0;
				nodes[i].GetDist(null, ref ret[i], ref node);
			}
			return ret;
		}
	}
}