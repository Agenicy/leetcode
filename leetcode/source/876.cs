using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q876
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
		public ListNode MiddleNode(ListNode head)
		{
			ListNode next = head;
			ListNode last = head;
			while(next?.next != null)
			{
				next = next.next?.next;
				last = last.next;
			}
			return last;
		}
	}
}