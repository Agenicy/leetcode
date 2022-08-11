using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q98
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.IsValidBST(TreeNode.Build("[5, 4, 6, null, null, 3, 7]")));

			Log.Print(solution.IsValidBST(TreeNode.Build("[2,1,3]")));
			Log.Print(solution.IsValidBST(TreeNode.Build("[5,1,4,null,null,3,6]")));
			Log.Print("The answer should be f/ t/ f");
		}
	}
	public class Solution
	{
		public bool IsValidBST(TreeNode root)
		{
			bool Validate(TreeNode par, int? min, int? max)
			{
				if (par == null)
					return true;

				if ((min == null ? true : min < par.val) && (max == null ? true : max > par.val))
					return (Validate(par.left, min, par.val) && Validate(par.right, par.val, max));
				else
					return false;
			}
			return Validate(root, null, null);
		}
	}
}