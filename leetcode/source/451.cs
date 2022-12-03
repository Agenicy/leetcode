using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace leetcode.Q451
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
		public string FrequencySort(string s)
		{
			Dictionary<char, int> counts = new Dictionary<char, int>();
			for (int i = 0; i < s.Length; i++)
			{
				if (!counts.ContainsKey(s[i]))
					counts[s[i]] = 1;
				else
					counts[s[i]]++;
			}
			PriorityQueue<(char, int), int> pq = new();
			foreach (var k in counts.Keys)
			{
				pq.Enqueue((k, counts[k]), -counts[k]);
			}
			StringBuilder sb = new();
			while (pq.Count > 0)
			{
				(char next, int times) = pq.Dequeue();
				sb.Append(next, times);
			}
			return sb.ToString();
		}
	}
}