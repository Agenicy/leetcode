using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q637
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
		public IList<double> AverageOfLevels(TreeNode root)
		{
			List<TreeNode> now = new() { root };
			List<double> res = new();
			double count;
			while(now.Count > 0)
			{
				List<TreeNode> next = new() {};
				count = 0;
				foreach (var item in now)
				{
					count += item.val;
					if (item.left != null)
						next.Add(item.left);
					if (item.right != null)
						next.Add(item.right);
				}
				res.Add(count / now.Count);
				now = next;
			}
			return res;
		}
	}
}