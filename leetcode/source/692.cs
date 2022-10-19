using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q692
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.TopKFrequent(new[] { "i", "love", "leetcode", "i", "love", "coding" }, 3));
			Log.Print(solution.TopKFrequent(new[] { "i", "love", "leetcode", "i", "love", "coding" }, 2));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public IList<string> TopKFrequent(string[] words, int k)
		{
			return words.GroupBy(w=>w)
				.OrderByDescending(freq=>freq.Count())
				.ThenBy(kvp=>kvp.Key)
				.Take(k)
				.Select(kvp=>kvp.Key)
				.ToList();
		}
	}
}