using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q199
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
	public class Parser
	{
		public static int[] ParseArr1D(string input)
		{
			System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
			input = input.Replace(" ", "").Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 1)
			{
				list.Add(int.Parse(array[i]));
			}
			return list.ToArray();
		}
		public static int[][] ParseArr2D(string input)
		{
			List<int[]> ret = new List<int[]>();
			input = input.Replace(" ", "");
			input = input.Substring(2, input.Length - 3);
			foreach (var s in input.Replace("],", "").Replace("]", "").Split("["))
			{
				string[] array = s.Split(',');
				var list = new List<int>(Enumerable.Range(0, array.Length).Select(x => int.Parse(array[x])));
				ret.Add(list.ToArray());
			}
			return ret.ToArray();
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

	public class Solution
	{
		public IList<int> RightSideView(TreeNode root)
		{
			List<int> ints = new List<int>();
			void trav(TreeNode node, int level)
			{
				if (ints.Count == level)
				{
					ints.Add(node.val);
				}
				else
				{
					ints[level] = node.val;
				}
				if(node.left != null)
					trav(node.left, level + 1);
				if (node.right != null)
					trav(node.right, level + 1);
			}
			if (root != null)
				trav(root, 0);

			IList<int> ret = new List<int>(ints);
			return ret;
		}
	}
}