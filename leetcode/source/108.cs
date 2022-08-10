using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q108
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SortedArrayToBST(Parser.ParseArr1D("[-10,-3,0,5,9]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public TreeNode SortedArrayToBST(int[] nums)
		{
			TreeNode GenBST(int fromInclude, int toExclude)
			{
				if (fromInclude + 1 == toExclude)
					return new TreeNode(nums[fromInclude]);
				else if (fromInclude == toExclude)
					return null;

				int root = (fromInclude + toExclude) / 2;
				TreeNode rootBST = new TreeNode(nums[root]);
				rootBST.left = GenBST(fromInclude, root);
				rootBST.right = GenBST(root+1, toExclude);
				return rootBST;
			}

			return GenBST(0, nums.Length);
		}


	}
}