using System;
using System.Collections.Generic;

namespace leetcode.Q97
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.IsInterleave(
				"abababababababababababababababababababababababababababababababababababababababababababababababababbb",
				"babababababababababababababababababababababababababababababababababababababababababababababababaaaba",
				"abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababbb"));
			Console.WriteLine(solution.IsInterleave(
				"bbbbbabbbbabaababaaaabbababbaaabbabbaaabaaaaababbbababbbbbabbbbababbabaabababbbaabababababbbaaababaa",
				"babaaaabbababbbabbbbaabaabbaabbbbaabaaabaababaaaabaaabbaaabaaaabaabaabbbbbbbbbbbabaaabbababbabbabaab",
				"babbbabbbaaabbababbbbababaabbabaabaaabbbbabbbaaabbbaaaaabbbbaabbaaabababbaaaaaabababbababaababbababbbababbbbaaaabaabbabbaaaaabbabbaaaabbbaabaaabaababaababbaaabbbbbabbbbaabbabaabbbbabaaabbababbabbabbab"));
			Console.WriteLine(solution.IsInterleave("aabc", "abad", "aabcabad"));
			Console.WriteLine(solution.IsInterleave("a", "b", "a"));
			Console.WriteLine(solution.IsInterleave("aabcc", "dbbca", "aadbbcbcac"));
			Console.WriteLine(solution.IsInterleave("aabcc", "dbbca", "aadbbbaccc"));
			Console.WriteLine(solution.IsInterleave("", "", ""));
			Console.WriteLine("The answer should be f/ f/ t/ f/ t/ f/ t");
		}
	}
	public class Solution
	{
		public bool IsInterleave(string s1, string s2, string s3)
		{
			int[] intCountA = new int[26];
			int[] intCountB = new int[26];
			for (int i = 0; i < s1.Length; i++)
			{
				intCountA[s1[i] - 'a']++;
			}
			for (int i = 0; i < s2.Length; i++)
			{
				intCountA[s2[i] - 'a']++;
			}
			for (int i = 0; i < s3.Length; i++)
			{
				intCountB[s3[i] - 'a']++;
			}
			for (int i = 0; i < 26; i++)
			{
				if (intCountA[i] != intCountB[i])
					return false;
			}
			return IsInterleaveBranch(s1, s2, s3);
		}

		bool IsInterleaveBranch(string s1, string s2, string s3)
		{
			if (s1.Length + s2.Length != s3.Length)
				return false;
			int s1Ind = 0, s2Ind = 0;
			for (int i = 0; i < s3.Length; i++)
			{
				bool s1Allow = s1Ind < s1.Length;
				bool s2Allow = s2Ind < s2.Length;
				if (s1Allow && s2Allow && s3[i] == s1[s1Ind] && s3[i] == s2[s2Ind])
				{
					if (s1Ind + 1 < s1.Length && s1[s1Ind + 1] == s3[i + 1] &&
						IsInterleaveBranch(s1.Substring(s1Ind + 1), s2.Substring(s2Ind), s3.Substring(i + 1)))
						return true;
					else if (IsInterleaveBranch(s1.Substring(s1Ind), s2.Substring(s2Ind + 1), s3.Substring(i + 1)))
						return true;
					else
						return false;
				}

				if (s1Allow && s3[i] == s1[s1Ind])
				{
					++s1Ind;
				}
				else if (s2Allow && s3[i] == s2[s2Ind])
				{
					++s2Ind;
				}
				else
				{
					return false;
				}
			}
			return s1Ind == s1.Length && s2Ind == s2.Length;
		}
	}
}