using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q102
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.ToString());
			Console.WriteLine("The answer should be ");
		}
	}
	public class Solution
	{
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			List<IList<int>> list = new();
			if (root == null)
				return list;

			Queue<TreeNode> nodes;
			Queue<TreeNode> nodes_next = new Queue<TreeNode>();
			nodes_next.Enqueue(root);
			List<int> level = new List<int>();
			while (nodes_next.Count > 0)
			{
				nodes = nodes_next;
				nodes_next = new Queue<TreeNode>();
				while (nodes.Count > 0)
				{
					var node = nodes.Dequeue();
					level.Add(node.val);
					if (node.left != null)
						nodes_next.Enqueue(node.left);
					if (node.right != null)
						nodes_next.Enqueue(node.right);
				}
				list.Add(level);
				level = new List<int>();
			}

			return list;
		}
	}
}