using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q345
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public string ReverseVowels(string s)
		{
			List<int> place = new();
			HashSet<char> set = new();
			set.Add('a');
			set.Add('A');
			set.Add('e');
			set.Add('E');
			set.Add('i');
			set.Add('I');
			set.Add('o');
			set.Add('O');
			set.Add('u');
			set.Add('U');

			for (int i = 0; i < s.Length; i++)
			{
				if (set.Contains(s[i]))
					place.Add(i);
			}
			int front = 0; int rear = place.Count - 1;
			StringBuilder sb = new(s);
			while (rear > front)
				(sb[place[front]], sb[place[rear]]) = (sb[place[rear--]], sb[place[front++]]);
			return sb.ToString();
		}
	}
}