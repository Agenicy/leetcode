using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q92
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			//Log.Print(solution.ReverseBetween());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public ListNode ReverseBetween(ListNode head, int left, int right)
		{
			Stack<int> stack = new Stack<int>();
			ListNode next = head;
			ListNode last = null;
			int ind = 1;
			while (next != null)
			{
				if(ind >= left && ind <= right)
				{
					stack.Push(next.val);
					next = next.next;
				}
				else
				{
					last = next = next.next;
				}
				if(ind == right)
				{
					foreach (var node in stack.Reverse())
					{
						var n = new ListNode(node);
						last.next = n;
						next = last = n;
					}
				}
				++ind;
			}
			return head;
		}
	}
}