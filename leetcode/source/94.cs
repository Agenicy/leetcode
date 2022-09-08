using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q94
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
		public IList<int> InorderTraversal(TreeNode root)
		{
			List<int> result = new();
			void InOrder(TreeNode parent)
			{
				if (parent is null)
					return;
				InOrder(parent.left);
				result.Add(parent.val);
				InOrder(parent.right);
			}
			InOrder(root);
			return result;
		}

	}
}