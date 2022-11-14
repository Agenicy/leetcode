using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q947
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.RemoveStones(Parser.ParseArr2D("[[3,2],[0,0],[3,3],[2,1],[2,3],[2,2],[0,2]]")));
			Log.Print(solution.RemoveStones(Parser.ParseArr2D("[[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]")));
			Log.Print(solution.RemoveStones(Parser.ParseArr2D("[[0,0],[0,2],[1,1],[2,0],[2,2]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int RemoveStones(int[][] stones)
		{
			Dictionary<int, int> rowDict = new();
			Dictionary<int, int> colDict = new();

			int[] parent = new int[stones.Length];
			Dictionary<int, HashSet<int>> child = new();

			int FindParent(int ind)
			{
				while (parent[ind] != ind)
					ind = parent[ind];
				return ind;
			}

			for (int i = 0; i < stones.Length; i++)
			{
				int row = stones[i][0];
				int col = stones[i][1];
				int parRow = -1, parCol = -1;
				if (!rowDict.ContainsKey(row))
					rowDict[row] = i;
				else
					parRow = FindParent(rowDict[row]);

				if (!colDict.ContainsKey(col))
					colDict[col] = i;
				else
					parCol = FindParent(colDict[col]);

				if (parRow == -1 & parCol == -1)
				{
					// new group
					parent[i] = i;
					child[i] = new();
				}
				else if (parRow == parCol)
				{
					parent[i] = parRow;
				}
				else if (parRow != -1 & parCol != -1)
				{
					// merge tree, col into row
					foreach (var node in child[parCol])
					{
						parent[node] = parRow;
						child[parRow].Add(node);
					}
					child.Remove(parCol);
					parent[i] = parRow;
				}
				else
				{
					parent[i] = Math.Max(parRow, parCol);
				}
				child[parent[i]].Add(i);
			}
			return stones.Length - child.Count();
		}
	}
}