using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1338
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MinSetSize(Parser.ParseArr1D("[3,3,3,3,5,5,5,2,2,7]")));
			Log.Print(solution.MinSetSize(Parser.ParseArr1D("[7,7,7,7,7,7]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MinSetSize(int[] arr)
		{
			int x, sum = 0;
			Dictionary<int, int> map = new();
			foreach (var num in arr)
			{
				sum += 1;
				if (map.TryGetValue(num, out x))
					map[num] = x + 1;
				else
					map[num] = 1;
			}

			PriorityQueue<int, int> pq = new();
			pq.EnqueueRange(map.Select(x => (x.Value, -x.Value)));

			float halfsum = sum / 2.0f;
			int i = 0;
			for (; sum > halfsum ; i++)
			{
				sum -= pq.Dequeue();
			}
			return i;
		}
	}
}