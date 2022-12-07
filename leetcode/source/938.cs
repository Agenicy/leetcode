using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace leetcode.Q938
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
		public int RangeSumBST(TreeNode root, int low, int high)
		{
			int count = 0;
			void Add(TreeNode parent)
			{
				if (parent == null) { return; }
				if (low <= parent.val & parent.val <= high)
					count += parent.val;
				Add(parent.left);
				Add(parent.right);
			}
			Add(root);
			return count;
		}
	}
}