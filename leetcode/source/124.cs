using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q124
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MaxPathSum(TreeNode.Build("[1,2,3]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MaxPathSum(TreeNode root)
		{
			int max = int.MinValue;
			int Prod(TreeNode par)
			{
				if (par == null) return 0;
				int left = Prod(par.left);
				int right = Prod(par.right);
				int me = (left > 0 ? left : 0) + (right > 0 ? right : 0) + par.val;
				max = Math.Max(max, me);
				return Math.Max(Math.Max(left, right), 0) + par.val;
			}
			Prod(root);
			return max;
		}
	}
}