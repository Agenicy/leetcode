using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q290
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
		public bool WordPattern(string pattern, string s)
		{
			int[] pat = new int[26];
			string[] vs = s.Split(' ');
			if (pattern.Length != vs.Length)
				return false;
			HashSet<int> matches = new HashSet<int>();	
			for (int i = 0; i < pattern.Length; i++)
			{
				int hash = vs[i].GetHashCode();
				if (pat[pattern[i] - 'a'] == 0)
				{
					if (matches.Contains(hash))
						return false;
					matches.Add(hash);
					pat[pattern[i] - 'a'] = hash;
				}
				else
				{
					if (pat[pattern[i] - 'a'] != hash)
						return false;
				}
			}
			return true;
		}
	}
}