using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace leetcode.Q1457
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.PseudoPalindromicPaths(TreeNode.Build("[9,5,4,5,null,2,6,2,5,null,8,3,9,2,3,1,1,null,4,5,4,2,2,6,4,null,null,1,7,null,5,4,7,null,null,7,null,1,5,6,1,null,null,null,null,9,2,null,9,7,2,1,null,null,null,6,null,null,null,null,null,null,null,null,null,5,null,null,3,null,null,null,8,null,1,null,null,8,null,null,null,null,2,null,8,7]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int PseudoPalindromicPaths(TreeNode root)
		{
			int sum = 0;

			void DFS(TreeNode treeNode, int record)
			{
				// flip
				record = record ^ (1 << treeNode.val);

				if (treeNode.left == null && treeNode.right == null)
				{
					if (BitOperations.IsPow2(record) || record == 0)
						++sum;
				}
				else
				{
					if(treeNode.left != null)
						DFS(treeNode.left, record);

					if (treeNode.right != null)
						DFS(treeNode.right, record);
				}
			}
			DFS(root, 0);
			return sum;
		}
	}
}