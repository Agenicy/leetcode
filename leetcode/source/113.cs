using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q113
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.PathSum(TreeNode.Build("[5,4,8,11,null,13,4,7,2,null,null,5,1]"), 22));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public IList<IList<int>> PathSum(TreeNode root, int targetSum)
		{
			List<IList<int>> result = new List<IList<int>>();

			if (root is null)
				return result;

			List<int> list = new List<int>();
			void DFS(TreeNode parent, int sumNow)
			{
				list.Add(parent.val);
				sumNow += parent.val;
				if (parent.left == null && parent.right == null)
				{
					if (sumNow == targetSum)
					{
						result.Add(new List<int>(list));
					}
				}
				else
				{
					if (parent.left != null)
						DFS(parent.left, sumNow);
					if (parent.right != null)
						DFS(parent.right, sumNow);
				}
				list.RemoveAt(list.Count - 1);
			}
			DFS(root, 0);
			return result;

		}
	}
}