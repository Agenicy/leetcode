using System;
using System.Collections.Generic;

namespace Q1647
{
	public class Solution
	{
		public int MinDeletions(string s)
		{
			if (s.Length == 0)
				return 0;
			PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(26);
			Dictionary<char, int> dict = new Dictionary<char, int>();
			for (int i = 0; i < s.Length; i++)
			{
				if (dict.ContainsKey(s[i]))
					dict[s[i]]++;
				else
					dict[s[i]] = 1;
			}

			foreach (var k in dict.Keys)
			{
				priorityQueue.Enqueue(dict[k], -dict[k]);
			}

			Queue<int> queue = new Queue<int>();

			int sum = 0;
			int freqNow = int.MaxValue;
			while (freqNow > 0 && priorityQueue.Count > 0)
			{
				if (freqNow == priorityQueue.Peek())
				{
					queue.Enqueue(priorityQueue.Dequeue());
				}
				else
				{
					// has an empty place
					if (queue.Count > 0 && (freqNow-1) > priorityQueue.Peek())
					{
						sum += queue.Dequeue() - (--freqNow);
					}
					else
					{
						if (priorityQueue.Count == 0)
							break;
						freqNow = priorityQueue.Dequeue();
					}
				}
			}
			while (queue.Count > 0)
			{
				sum += (freqNow > 0) ? queue.Dequeue() - (--freqNow) : queue.Dequeue();
			}


			return sum;
		}
	}
}