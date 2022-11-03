using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;

namespace leetcode.Q2131
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.LongestPalindrome(new[] { "ab", "ty", "yt", "lc", "cl", "ab" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int LongestPalindrome(string[] words)
		{
			Dictionary<string, int> palindrome = new();
			foreach (string word in words)
			{
				if(!palindrome.ContainsKey(word))
					palindrome[word] = 0;
				palindrome[word] += 1;
			}

			int res = 0;
			int cent = 0;
			while (palindrome.Count > 0)
			{
				string next = palindrome.First().Key;
				string txen = "" + next[1] + next[0];

				palindrome[next] -= 1;
				if (palindrome[next] == 0)
					palindrome.Remove(next);

				if (palindrome.ContainsKey(txen))
				{
					palindrome[txen] -= 1;
					if (palindrome[txen] == 0)
						palindrome.Remove(txen);
					res += 4;
				}
				else if (next == txen)
					cent = 2;
			}
			return res + cent;
		}
	}
}