using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1704
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
		public bool HalvesAreAlike(string s)
		{
			int count = 0;
			HashSet<char> vowel = new() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
			for (int i = 0; i < s.Length/2; i++)
			{
				if (vowel.Contains(s[i]))
				{
					count++;
				}
			}
			for (int i = s.Length / 2; i < s.Length; i++)
			{
				if (vowel.Contains(s[i]))
				{
					count--;
				}
			}
			return count == 0;
		}
	}
}