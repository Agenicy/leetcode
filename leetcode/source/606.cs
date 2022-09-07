using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q606
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
		public string Tree2str(TreeNode root)
		{
			StringBuilder sb = new();
			Preorder(root, ref sb);
			return sb.ToString();
		}

		public void Preorder(TreeNode root, ref StringBuilder sb)
		{
			if (root == null)
				return;
			else
			{
				sb.Append(root.val.ToString());

				bool left = (root.left != null), right = (root.right != null);

				if (left || right)
				{
					sb.Append($"(");
					if (left)
						Preorder(root.left, ref sb);
					sb.Append($")");
				}
				if (right)
				{
					sb.Append($"(");
					Preorder(root.right, ref sb);
					sb.Append($")");
				}
			}
		}
	}
}