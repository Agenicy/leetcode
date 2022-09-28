using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q19
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.RemoveNthFromEnd(ListNode.Build(Parser.ParseArr1D("[1,2,3,4,5]")), 2));
			Log.Print(solution.RemoveNthFromEnd(ListNode.Build(Parser.ParseArr1D("[1,2]")), 2));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public ListNode RemoveNthFromEnd(ListNode head, int n)
		{
			int length;
			ListNode front = new(0, head);
			ListNode now = front;
			for (length = 0; now.next != null; length++)
			{
				now = now.next;
			}

			if (length < 1)
				return null;

			now = front;
			for (int i = 0; i <= length - n; i++)
			{
				if (i == length-n)
					now.next = now.next.next;
				now = now.next;
			}
			return front.next;
		}
	}
}