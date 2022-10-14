using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q2095
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
		public ListNode DeleteMiddle(ListNode head)
		{
			ListNode front, mid, rear;
			front = new ListNode(0, head);
			rear = front;
			mid = front;
			while (rear?.next?.next != null)
			{
				rear = rear.next.next;
				mid = mid.next;
			}
			mid.next = mid.next?.next;
			return front.next;
		}
	}
}