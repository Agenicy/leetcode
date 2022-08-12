using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q235
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
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
		{

			bool Test(TreeNode that) => that == p || that == q;
			if (Test(root)) return root;

			TreeNode ret = null;
			bool earlyStop = false;
			int DFS(TreeNode now)
			{
				if (earlyStop) return 0;

				int count = 0;

				if (Test(now))
				{
					count++;
				}

				if (now.left != null)
					count += DFS(now.left);
				if (now.right != null)
					count += DFS(now.right);

				if (count == 2)
				{
					ret = now;
					earlyStop = true;
					return 0;
				}
				return count;

			}
			DFS(root);
			return ret;
		}
	}
}