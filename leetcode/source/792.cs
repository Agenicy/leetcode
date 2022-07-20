using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q792
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.NumMatchingSubseq("abcde", new[] { "a", "bb", "acd", "ace" }));
			Log.Print(solution.NumMatchingSubseq("dsahjpjauf", new[] { "ahjpjau", "ja", "ahbwzgqnuk", "tnmlanowax" }));
			Log.Print("The answer should be 3/ 2");
		}
	}
	public class Solution
	{
		public int NumMatchingSubseq(string s, string[] words)
		{
			int Sub(string orig, string s)
			{
				int ind = 0;
				for (int i = 0; i < orig.Length; i++)
				{
					if (s[ind] == orig[i])
						++ind;
					if (ind == s.Length)
						break;
				}
				return ind == s.Length ? 1 : 0;
			}
			return words.Sum(x => Sub(s, x));
		}
	}
}