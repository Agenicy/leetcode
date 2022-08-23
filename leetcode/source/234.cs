using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q234
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.IsPalindrome(ListNode.Build(Parser.ParseArr1D("[1,2,2,1]"))));
			Log.Print(solution.IsPalindrome(ListNode.Build(Parser.ParseArr1D("[1,2]"))));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool IsPalindrome(ListNode head)
		{
			List<int> list = new();
			while (head != null)
			{
				list.Add(head.val);
				head = head.next;
			}
			var fr = 0;
			var en = list.Count - 1;
			while (fr <= en)
			{
				if (list[fr] == list[en])
				{
					++fr;
					--en;
				}
				else
				{
					return false;
				}
			}
			return true;
		}
	}
}