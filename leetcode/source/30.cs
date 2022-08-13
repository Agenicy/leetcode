using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q30
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Log.Print(solution.FindSubstring("ababaab", new[] { "ab", "ba", "ba" }));
			Log.Print(solution.FindSubstring("lingmindraboofooowingdingbarrwingmonkeypoundcake", new[] { "fooo", "barr", "wing", "ding", "wing" }));
			Log.Print(solution.FindSubstring("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "good" }));
			Log.Print(solution.FindSubstring("barfoothefoobarman", new[] { "foo", "bar" }));
			Log.Print(solution.FindSubstring("wordgoodgoodgoodbestword", new[] { "word", "good", "best", "word" }));
			Log.Print(solution.FindSubstring("barfoofoobarthefoobarman", new[] { "bar", "foo", "the" }));
			Log.Print("The answer should be [13]/ [8]/ [0,9]/ []/ [6,9,12]");
		}
	}
	public class Solution
	{
		public IList<int> FindSubstring(string s, string[] words)
		{
			Dictionary<string, int> map = new();
			foreach (string word in words)
				if (!map.ContainsKey(word))
					map[word] = map.Count;

			short[] ans = new short[map.Count];
			foreach (string word in words)
				ans[map[word]]++;

			int block = words[0].Length;



			List<int> ret = new();
			for (int i = 0; i <= s.Length - block * words.Length; i++)
			{
				short[] statistic = new short[map.Count];
				bool skip = false;
				for (int w = i; w < i + block * words.Length; w += block)
				{
					int index;
					if (map.TryGetValue(s.Substring(w, block), out index))
						++statistic[index];
					else
					{
						skip = true;
						break;
					}
				}
				if (skip)
					continue;


				if (Enumerable.SequenceEqual(statistic, ans))
				{
					ret.Add(i);
				}
			}
			return ret;
		}
	}
}