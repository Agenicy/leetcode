using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1669
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
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int val = 0, ListNode next = null)
		{
			this.val = val;
			this.next = next;
		}
	}
	public class Solution
	{
		public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
		{
			ListNode first = list1;
			ListNode now = list1;

			for (int i = 1; i < a; i++)
			{
				now = now.next;
			}
			ListNode passTo = now.next;
			for (int i = a; i <= b; i++)
			{
				passTo = passTo.next;
			}

			now.next = list2;

			while (now.next != null)
				now = now.next;

			now.next = passTo;
			return first;
		}
	}
}