using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1448
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.GoodNodes(TreeNode.Build("[3,1,4,3,null,1,5]")));
			Log.Print(solution.GoodNodes(TreeNode.Build("[3,3,null,4,2]")));
			Log.Print(solution.GoodNodes(TreeNode.Build(" [1]")));
			Log.Print("The answer should be 4/ 3/ 1");
		}
	}
	public class Solution
	{
		public int GoodNodes(TreeNode root)
		{
			int sum = 0;
			Expand(ref sum, root, int.MinValue);
			return sum;
		}

		void Expand(ref int sum, TreeNode parent, int localMax)
		{
			if (parent.val >= localMax)
				sum++;

			localMax = Math.Max(localMax, parent.val);
			if(parent.left != null)
				Expand(ref sum, parent.left, localMax);
			if (parent.right != null)
				Expand(ref sum, parent.right, localMax);
		}
	}
}