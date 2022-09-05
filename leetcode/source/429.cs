using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace leetcode.Q429
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
	public class Node
	{
		public int val;
		public IList<Node> children;

		public Node() { }

		public Node(int _val)
		{
			val = _val;
		}

		public Node(int _val, IList<Node> _children)
		{
			val = _val;
			children = _children;
		}
	}
	public class Solution
	{
		public IList<IList<int>> LevelOrder(Node root)
		{
			List<IList<int>> levelOrder = new List<IList<int>>();

			if (root == null)
				return levelOrder;

			List<Node> now = new() { root };
			while (now.Count > 0)
			{
				List<int> temp = new(now.Count);
				List<Node> next = new(now.Count);
				foreach (var node in now)
				{
					temp.Add(node.val);
					next.AddRange(node.children);
				}
				levelOrder.Add(temp);
				now = next;
			}
			return levelOrder;
		}
	}
}