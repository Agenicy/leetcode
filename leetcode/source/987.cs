using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;

namespace leetcode.Q987
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.VerticalTraversal(TreeNode.Build("[0,8,1,null,null,3,2,null,4,5,null,null,7,6]")));
			Log.Print(solution.VerticalTraversal(TreeNode.Build("[3,1,4,0,2,2]")));
			Log.Print(solution.VerticalTraversal(TreeNode.Build("[1,2,3,4,5,6,7]")));
			Log.Print("The answer should be [[4],[2],[1,5,6],[3],[7]]");
		}
	}
	public class Solution
	{
		public IList<IList<int>> VerticalTraversal(TreeNode root)
		{
			SortedList<int, IList<int>> result = new();

			SortedDictionary<(int, int), List<int>> temp = new();

			void Helper(TreeNode parent, int index, int layer)
			{
				if (!temp.ContainsKey((index, layer)))
				{
					temp[(index, layer)] = new List<int>();
				}
				temp[(index, layer)].Add(parent.val);

				if (parent.left != null)
					Helper(parent.left, index - 1, layer + 1);
				if (parent.right != null)
					Helper(parent.right, index + 1, layer + 1);
			}
			Helper(root, 2048, 0);

			foreach (var k in temp.Keys)
			{
				(int index, int layer) = k;
				if (!result.ContainsKey(index))
					result[index] = new List<int>();
				temp[k].Sort();
				(result[index] as List<int>).AddRange(temp[k]);
			}

			return result.Values;
		}
	}

}