using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q890
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindAndReplacePattern(new[] { "abc", "deq", "mee", "aqq", "dkd", "ccc"} , "abb"));
			Log.Print("The answer should be [mee,aqq]");
		}
	}
	public class Solution
	{
		public IList<string> FindAndReplacePattern(string[] words, string pattern)
		{
			List<int> patCode = new List<int>(20);
			Dictionary<char, int> patChar = new();

			for (int i = 0; i < pattern.Length; i++)
			{
				if (patChar.ContainsKey(pattern[i]))
				{
					patCode.Add(patChar[pattern[i]]);
				}
				else
				{
					patChar[pattern[i]] = patCode.Count;
					patCode.Add(patCode.Count);
				}
			}

			List<string> ret = new();
			foreach (var word in words)
			{

				List<int> apCode = new List<int>(20);
				Dictionary<char, int> apChar = new();

				for (int i = 0; i < word.Length; i++)
				{
					if (apChar.ContainsKey(word[i]))
					{
						apCode.Add(apChar[word[i]]);
					}
					else
					{
						apChar[word[i]] = apCode.Count;
						apCode.Add(apCode.Count);
					}
					if (apCode[i] != patCode[i])
						break;
					if (i == word.Length - 1)
						ret.Add(word);
				}
			}
			return ret;
		}
	}
}