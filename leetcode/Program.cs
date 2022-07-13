using System;
using System.Collections.Generic;

namespace leetcode
{
	partial class Program
	{
		static void Main(string[] args)
		{
			Q473.Program.Run();
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
	}
}
