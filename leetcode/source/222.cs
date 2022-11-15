using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q222
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
		public int CountNodes(TreeNode root)
		{
			if (root == null)
				return 0;

			int count = 1;
			void DFS(TreeNode parent)
			{
				if(parent.left != null)
				{
					count++;
					DFS(parent.left);
				}
				if(parent.right != null)
				{
					count++;
					DFS(parent.right);
				}
			}
			DFS(root);
			return count;
		}
	}
}