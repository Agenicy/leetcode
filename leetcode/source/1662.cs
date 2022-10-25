using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1662
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ArrayStringsAreEqual(new[] { "ab", "c" }, new[] { "a", "bc" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool ArrayStringsAreEqual(string[] word1, string[] word2)
		{
			return new StringBuilder().AppendJoin("", word1).ToString() == new StringBuilder().AppendJoin("", word2).ToString();
		}
	}
}