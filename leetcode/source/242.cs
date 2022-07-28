using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q242
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
		public bool IsAnagram(string s, string t)
		{
			int[] count = new int[26];
			for (int i = 0; i < s.Length; i++)
			{
				count[s[i] - 'a']++;
			}

			int[] countB = new int[26];
			for (int i = 0; i < t.Length; i++)
			{
				countB[t[i] - 'a']++;
			}
			return Enumerable.Range(0, 26).All(x => count[x] == countB[x]);
		}
	}
}