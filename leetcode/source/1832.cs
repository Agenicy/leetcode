using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1832
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.CheckIfPangram("thequickbrownfoxjumpsoverthelazydog"));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool CheckIfPangram(string sentence)
		{
			int[] check = new int[26];
			foreach (var c in sentence)
			{
				int ind = c - 'a';
				check[ind] += 1;
			}
			return check.All(x=>x>0);
		}
	}
}