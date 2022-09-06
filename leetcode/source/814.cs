using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q814
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
		public TreeNode PruneTree(TreeNode root)
		{
			if (Travsal(root))
				return root;
			else
				return null;
		}

		bool Travsal(TreeNode parent)
		{
			bool left = false, right = false, mid = parent.val == 1;
			if (!(parent.left is null))
			{
				if (!(left = Travsal(parent.left)))
					parent.left = null;
			}
			if (!(parent.right is null))
			{
				if (!(right = Travsal(parent.right)))
					parent.right = null;
			}
			return left || right || mid;
		}
	}
}