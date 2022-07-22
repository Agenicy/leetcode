using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q86
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.Partition(ListNode.Build(new[] { 1 }), 0).ToString());
			Log.Print(solution.Partition(ListNode.Build(new[] { 1, 4, 3, 2, 5, 2 }), 3).ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public ListNode Partition(ListNode head, int x)
		{
			if (head == null) return head;

			ListNode first = null, firstLast = null, second = null, secondLast = null, next = head;

			while (next != null)
			{
				if (next.val < x)
				{
					if (first == null)
						first = firstLast = next;
					else
					{
						firstLast.next = next;
						firstLast = firstLast.next;
					}
				}
				else
				{
					if (second == null)
						second = secondLast = next;
					else
					{
						secondLast.next = next;
						secondLast = secondLast.next;
					}
				}
				next = next.next;
			}
			if (secondLast != null)
				secondLast.next = null;
			if(firstLast!=null)
				firstLast.next = second;

			if (first != null)
				return first;
			else
				return second;
		}
	}
}