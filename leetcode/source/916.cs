using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q916
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "lo", "eo" }));
			Log.Print(solution.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "e", "o" }));
			Log.Print(solution.WordSubsets(new[] { "amazon", "apple", "facebook", "google", "leetcode" }, new[] { "l", "e" }));
			Log.Print("The answer should be [\"facebook\",\"google\",\"leetcode\"]/ [\"apple\",\"google\",\"leetcode\"]");
		}
	}
	public class Solution
	{
		public IList<string> WordSubsets(string[] words1, string[] words2)
		{
			int[,] count = new int[words1.Length, 26];

			for (int i = 0; i < words1.Length; i++)
			{
				for (int j = 0; j < words1[i].Length; j++)
				{
					count[i, words1[i][j] - 'a']++;
				}
			}

			int[] check = new int[26];
			for (int i = 0; i < words2.Length; i++)
			{
				int[] check2 = new int[26];
				for (int j = 0; j < words2[i].Length; j++)
				{
					int place = words2[i][j] - 'a';
					check2[place]++;
					if (check2[place] > check[place])
						check[place] = check2[place];
				}
			}
			List<string> ret = new();
			for (int i = 0; i < words1.Length; i++)
			{
				for (int j = 0; j < 26; j++)
				{
					if (count[i, j] < check[j])
						break;
					else if(j == 25)
						ret.Add(words1[i]);
				}
			}
			return ret;
		}
	}
}