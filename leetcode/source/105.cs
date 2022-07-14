using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q105
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			TreeNode.Preorder(solution.BuildTree(Parser.ParseArr1D("[3,9,20,15,7]"), Parser.ParseArr1D("[9,3,15,20,7]")));
			Console.WriteLine("The answer should be [3,9,20,null,null,15,7]");
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
	}
	public class Solution
	{
		public TreeNode BuildTree(int[] preorder, int[] inorder)
		{
			Dictionary<int, int> dictInorder = new();
			for (int i = 0; i < inorder.Length; i++)
			{
				dictInorder[inorder[i]] = i;
			}

			TreeNode root = new TreeNode(preorder[0]);

			int preorderInd = 1;
			TreeNode Build(int rootInd, int leftInclusive, int rightExclusive)
			{
				if (leftInclusive >= rightExclusive)
					return null;

				int ind = preorderInd++;

				TreeNode node = new TreeNode(preorder[ind]);

				node.left = Build(0, leftInclusive, dictInorder[node.val]);
				node.right = Build(0, dictInorder[node.val] + 1, rightExclusive);

				return node;
			}

			root.left = Build(0, 0, dictInorder[root.val]);
			root.right = Build(0, dictInorder[root.val] + 1, inorder.Length);

			return root;
		}
	}
}