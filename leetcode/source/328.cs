using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q328
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.OddEvenList(null));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public ListNode OddEvenList(ListNode head)
		{
			if (head?.next == null) return head;
			ListNode odd, even, oddHead, evenHead;
			oddHead = odd = head;
			evenHead = even = head.next;
			for (int i = 0; odd.next != null & even.next != null; i++)
			{
				if(i%2==0)
				{
					odd = odd.next = even.next;
				}
				else
				{
					even = even.next = odd.next;
				}
			}
			odd.next = evenHead;
			even.next = null;
			return oddHead;
		}
	}
}