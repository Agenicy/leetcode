using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1047
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
		public string RemoveDuplicates(string s)
		{
			Stack<char> stack = new();
			for (int i = 0; i < s.Length; i++)
			{
				if (stack.Count > 0 && s[i] == stack.Peek())
					stack.Pop();
				else
					stack.Push(s[i]);
			}
			var tmp = stack.Reverse();
			StringBuilder sb = new();
			foreach (var item in tmp)
			{
				sb.Append(item);
			}
			return sb.ToString();
		}
	}
}