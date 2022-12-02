using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1657
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.CloseStrings("abc","bca"));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool CloseStrings(string word1, string word2)
		{
			if (word1.Length != word2.Length)
				return false;
			int[] count1 = new int[26], count2 = new int[26];
			void CountChar(string word, ref int[] array)
			{
				for (int i = 0; i < word.Length; i++)
				{
					array[word[i] - 'a']++;
				}
			}
			CountChar(word1, ref count1);
			CountChar(word2, ref count2);
			if (Enumerable.Range(0, 26).Any(i => count1[i] == 0 ^ count2[i] == 0))
				return false;
			Array.Sort(count1);
			Array.Sort(count2);
			return Enumerable.Range(0, 26).All(i => count1[i] == count2[i]);
		}
	}
}