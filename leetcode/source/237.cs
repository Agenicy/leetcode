using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q237
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
		public void DeleteNode(ListNode node)
		{
			node.val = node.next.val;
			if (node.next.next == null)
				node.next = null;
			else
				DeleteNode(node.next);
		}
	}
}