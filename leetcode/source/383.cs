using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q383
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
		public bool CanConstruct(string ransomNote, string magazine)
		{
			short[] count = new short[26];
			for (int i = 0; i < magazine.Length; i++)
			{
				count[magazine[i] - 'a']++;
			}
			for (int i = 0; i < ransomNote.Length; i++)
			{
				count[ransomNote[i] - 'a']--;
				if (count[ransomNote[i] - 'a'] < 0)
					return false;
			}
			return true;
		}
	}
}