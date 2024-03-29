﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q804
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.UniqueMorseRepresentations(new[] { "gin", "zen", "gig", "msg" }));
			Log.Print(solution.UniqueMorseRepresentations(new[] { "a" }));
			Log.Print("The answer should be 2/ 1");
		}
	}
	public class Solution
	{
		readonly static string[] map = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

		public int UniqueMorseRepresentations(string[] words)
		{
			HashSet<string> result = new HashSet<string>();

			for (int i = 0; i < words.Length; i++)
			{
				StringBuilder sb = new();
				for (int j = 0; j < words[i].Length; j++)
				{

					sb.Append(map[words[i][j] - 'a']);
				}
				result.Add(sb.ToString());
			}
			return result.Count;
		}

	}
}