using System;
using System.Collections.Generic;

namespace leetcode
{
	partial class Program
	{
		static void Main(string[] args)
		{
			Q576.Program.Run();
		}
	}

	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}

		public static void Preorder(TreeNode root)
		{
			if (root == null)
				Console.WriteLine("[null]");
			else
			{
				Console.Write("[" + root.val.ToString());
				Queue<TreeNode> treeNodes = new Queue<TreeNode>();
				treeNodes.Enqueue(root.left);
				treeNodes.Enqueue(root.right);

				while (treeNodes.Count > 0)
				{
					var next = treeNodes.Dequeue();
					if (next == null)
					{
						Console.Write(",null");
					}
					else
					{
						Console.Write("," + next.val.ToString());
						treeNodes.Enqueue(next.left);
						treeNodes.Enqueue(next.right);
					}
				}
				Console.Write("]\n");
			}
		}
	}
}
