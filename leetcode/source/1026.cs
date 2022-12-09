using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1026
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MaxAncestorDiff(TreeNode.Build("[2,0,8,3,10,7,1,4,null,null,null,null,null,null,6,5,null,9]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MaxAncestorDiff(TreeNode root)
		{
			(int, int) Count(TreeNode parent, ref int maxDiff)
			{
				if ((parent.left == null) & (parent.right == null))
				{
					return (parent.val, parent.val);
				}
				int min = int.MaxValue;
				int max = int.MinValue;
				if (parent.left != null)
				{
					(min, max) = Count(parent.left, ref maxDiff);
				}
				if (parent.right != null)
				{
					(int m, int M) = Count(parent.right, ref maxDiff);
					min = Math.Min(min, m);
					max = Math.Max(max, M);
				}

				if (parent.val < min)
					min = parent.val;
				else
					maxDiff = Math.Max(maxDiff, Math.Abs(parent.val - min));
				if (parent.val > max)					max = parent.val;
				else
					maxDiff = Math.Max(maxDiff, Math.Abs(parent.val - max));
				return (min, max);
			}
			int MD = 0;
			Count(root, ref MD);
			return MD;
		}
	}
}