using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q387
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FirstUniqChar("leetcode"));
			Log.Print(solution.FirstUniqChar("loveleetcode"));
			Log.Print(solution.FirstUniqChar("aabb"));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int FirstUniqChar(string s)
		{

			int[] count = new int[26];

			for (int i = 0; i < s.Length; i++)
			{
				count[s[i] - 'a']++;
			}

			for (int i = 0; i < s.Length; i++)
				if (count[s[i] - 'a'] == 1)
					return i;
			return -1;
		}
	}
}