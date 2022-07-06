using System;
using System.Collections.Generic;

namespace leetcode.Q3
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.LengthOfLongestSubstring("bbtablud"));
			Console.WriteLine(solution.LengthOfLongestSubstring("abcabcbb"));
			Console.WriteLine(solution.LengthOfLongestSubstring("bbbbb"));
			Console.WriteLine(solution.LengthOfLongestSubstring("pwwkew"));
			Console.WriteLine("The answer should be 6/ 3/ 1/ 3 ");
		}
	}
	public class Solution
	{
		public int LengthOfLongestSubstring(string s)
		{
			Dictionary<char, int> dict = new Dictionary<char, int>();
			int front = 0, max = 0, place;
			for (int rear = 0; rear < s.Length; rear++)
			{
				if (dict.TryGetValue(s[rear], out place))
				{
					for (int i = front; i < place; i++)
					{
						dict.Remove(s[i]);
					}
					front = place + 1;
					dict[s[rear]] = rear;
				}
				else
				{
					dict[s[rear]] = rear;
					max = Math.Max(rear - front +1, max);
				}
			}
			return max;
		}
	}
}