using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q557
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
		public string ReverseWords(string s)
		{
			return string.Join(' ', s.Split(' ').Select(x => new string(x.Reverse().ToArray())));
		}
	}
}