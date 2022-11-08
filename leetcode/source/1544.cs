using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1544
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
		public string MakeGood(string s)
		{
			Stack<char> st = new();
			for (int i = 0; i < s.Length; i++)
			{
				if (st.Count == 0)
					st.Push(s[i]);
				else
				{
					if (Math.Abs(s[i] - st.Peek()) == Math.Abs('A' - 'a'))
						st.Pop();
					else
						st.Push(s[i]);
				}
			}
			StringBuilder sb = new StringBuilder(st.Count);
			while(st.Count > 0)
			{
				sb.Insert(0, st.Pop());
			}
			return sb.ToString();
		}
	}
}