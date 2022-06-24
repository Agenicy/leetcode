using System;
using System.Collections.Generic;

namespace Q1354
{
	public class Parser
	{
		public static int[] Parse(string input)
		{
			List<int> list = new List<int>();
			input = input.Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 1)
			{
				list.Add(int.Parse(array[i]));
			}
			return list.ToArray();
		}
	}

	public class Solution
	{
		public bool IsPossible(int[] target)
		{
			if (target.Length == 1 && target[0] != 1)
				return false;

			// 9/ 5/ 3
			PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
			long sum = 0;
			checked
			{
				for (int i = 0; i < target.Length; i++)
				{
					priorityQueue.Enqueue(target[i], -target[i]);
					sum += target[i];
				}


				while (priorityQueue.Peek() > 1)
				{
					int top = priorityQueue.Peek(); // 9
					long sumLeft = sum - top; // 5+3 = 8

					if (top - 1 < sumLeft)
						return false;

					long next = top - ((top - 1) / sumLeft) * sumLeft; // 9-8 = 1

					if (next < 1)
						return false;
					sum = sum - top + next;
					priorityQueue.EnqueueDequeue((int)next, -(int)next);
				}
			}

			return true;
		}
	}
}