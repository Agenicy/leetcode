using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q621
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.LeastInterval(new[] { 'A', 'A', 'A', 'B', 'B', 'B', 'C', 'C', 'C', 'D', 'D', 'E' }, 2));
			Log.Print("The answer should be 12");
			Log.Print(solution.LeastInterval(new[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2));
			Log.Print("The answer should be 8");
			Log.Print(solution.LeastInterval(new[] { 'A', 'C', 'A', 'B', 'D', 'B' }, 1));
			Log.Print("The answer should be 6");
			Log.Print(solution.LeastInterval(new[] { 'A', 'A', 'B' }, 2));
			Log.Print("The answer should be 4");
		}
	}
	public class Solution
	{
		public int LeastInterval(char[] tasks, int n)
		{
			int[] freq = new int[26];
			int max = 0;
			int maxCount = 0;
			foreach (char task in tasks)
			{
				freq[task - 'A']++;
				if (max == freq[task - 'A'])
				{
					maxCount++;
				}
				else if (max < freq[task - 'A'])
				{
					max = freq[task - 'A'];
					maxCount = 1;
				}
			}

			int gapCount = max - 1;
			int gapLength = n - (maxCount - 1);
			int empty = gapCount * gapLength;
			int availableTasks = tasks.Length - max * maxCount;
			int idles = Math.Max(0, empty - availableTasks);

			return tasks.Length + idles;
		}
	}
}