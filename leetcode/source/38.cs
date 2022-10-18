using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q38
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.CountAndSay(1));
			Log.Print(solution.CountAndSay(2));
			Log.Print(solution.CountAndSay(3));
			Log.Print(solution.CountAndSay(4));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public string CountAndSay(int n)
		{
			if (n == 1) return "1";

			string last = CountAndSay(n - 1);
			int now=0, ptr = 0;
			StringBuilder sb = new();
			while(ptr < last.Length)
			{
				now = last[ptr];

				int i;
				for (i = ptr + 1; i < last.Length; i++)
				{
					if (last[i] != now) break;
				}
				sb.Append(i - ptr);
				sb.Append(now-'0');
				ptr = i;
			}
			return sb.ToString();
		}
	}
}