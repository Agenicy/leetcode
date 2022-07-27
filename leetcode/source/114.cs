using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q114
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
		public void Flatten(TreeNode root)
		{
			if (root == null) return;

			TreeNode treeNode = root;
			TreeNode last = null;
			void DFS(TreeNode now)
			{
				if (now == null) return;

				TreeNode left = now.left;
				TreeNode right = now.right;

				now.left = null;
				if(last != null)
					last.right = now;
				last = now;

				DFS(left);
				DFS(right);
			}
			DFS(root);
		}
	}
}