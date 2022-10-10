using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1328
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
		public string BreakPalindrome(string palindrome)
		{
			if (palindrome.Length == 1)
				return "";
			char[] p = palindrome.ToCharArray();
			for (int i = 0; i < palindrome.Length / 2; i++)
			{
				if (p[i] != 'a')
				{
					p[i] = 'a';
					return new string(p);
				}
			}
			p[p.Length - 1] = 'b';
			return new string(p);
		}
	}
}