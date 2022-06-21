using System;
using System.Collections.Generic;

namespace Q820
{
	public class Solution
	{
		public int MinimumLengthEncoding(string[] words)
		{
			Tree tree = new Tree();
			foreach (string word in words)
			{
				List<char> chars = new List<char>(word);

				tree.Insert(chars);
			}

			return tree.GetAnswer();
		}

		class Tree
		{

			Node root;

			public Tree()
			{
				root = new Node();
			}

			public void Insert(List<char> vs)
			{
				root.Insert(vs);
			}

			public int GetAnswer()
			{
				int Num = 0;
				foreach (var node in Node.allNode)
				{
					if (node.isLeaf)
						Num += node.height + 1;
				}
				return Num;
			}
		}

		class Node
		{
			public int height;

			public List<Node> child;

			public static List<Node> allNode;

			public bool isLeaf = true;

			char value;

			public Node()
			{
				allNode = new List<Node>();

				height = 0;
				child = new List<Node>();
			}

			public Node(char c, int height)
			{
				value = c;
				this.height = height;
				child = new List<Node>();

				allNode.Add(this);
			}

			public bool Compare(char v) => v == value;

			public int Insert(List<char> vs)
			{
				if (vs.Count == 0)
					return height;

				isLeaf = false;

				char keyword = vs[vs.Count - 1];
				vs.RemoveAt(vs.Count - 1);

				foreach (var c in child)
				{
					if (c.Compare(keyword) == true)
					{
						return c.Insert(vs);
					}
				}

				// new child
				var node = new Node(keyword, height + 1);

				child.Add(node);
				node.Insert(vs);

				return height;
			}
		}
	}
}