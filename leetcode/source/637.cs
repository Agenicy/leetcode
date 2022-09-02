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
			while(now.Count > 0)
			{
				List<TreeNode> next = new() { root };
				res.Add(next.Average(x=>x.val));

			}
		}
	}
}