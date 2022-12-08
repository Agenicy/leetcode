using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q872
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.LeafSimilar(TreeNode.Build(
				"[3,5,1,6,7,4,2,null,null,null,null,null,null,9,11,null,null,8,10]"), TreeNode.Build(
					"[3,5,1,6,2,9,8,null,null,7,4]")));
			Log.Print(solution.LeafSimilar(TreeNode.Build("[3,5,1,6,2,9,8,null,null,7,4]"), TreeNode.Build("[3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool LeafSimilar(TreeNode root1, TreeNode root2)
		{
			Queue<TreeNode> list = new();
			void FindLeaf(TreeNode parent)
			{
				if (parent.left == null & parent.right == null)
				{
					list.Enqueue(parent);
					return;
				}
				if (parent.left != null)
					FindLeaf(parent.left);
				if (parent.right != null)
					FindLeaf(parent.right);
			}
			FindLeaf(root1);
			bool TestLeaf(TreeNode parent)
			{
				if (parent.left == null & parent.right == null)
				{
					return list.Count > 0 && (parent.val == list.Dequeue().val);
				}
				if (parent.left != null)
					if (!TestLeaf(parent.left))
						return false;
				if (parent.right != null)
					if (!TestLeaf(parent.right))
						return false;
				return true;
			}
			return TestLeaf(root2) & list.Count == 0;
		}
	}
}