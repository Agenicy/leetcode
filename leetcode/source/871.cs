using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q871
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MinRefuelStops(100, 50, Parser.ParseArr2D("[[50,50]]")));
			Log.Print(solution.MinRefuelStops(1, 1, new int[0][]));
			Log.Print(solution.MinRefuelStops(100, 1, Parser.ParseArr2D("[[10,100]]")));
			Log.Print(solution.MinRefuelStops(100, 1, Parser.ParseArr2D("[[10,100]]")));
			Log.Print(solution.MinRefuelStops(100, 10, Parser.ParseArr2D("[[10,60],[20,30],[30,30],[60,40]]")));
			Log.Print("The answer should be 1/ 0/ -1/ 2");
		}
	}
	public class Solution
	{
		public int MinRefuelStops(int target, int startFuel, int[][] stations)
		{
			if (startFuel >= target) return 0;

			PriorityQueue<int, int> pq = new();

			int i = 0;
			for (; i < stations.Length; i++)
			{
				if (stations[i][0] <= startFuel)
					pq.Enqueue(stations[i][1], -stations[i][1]);
				else break;
			}

			if (pq.Count == 0)
				return -1;

			int km = startFuel;
			int count = 0;
			do
			{
				int best = pq.Dequeue();
				km += best;
				++count;
				if (km >= target)
					return count;
				else
				{
					for (; i < stations.Length; i++)
					{
						if (stations[i][0] <= km)
							pq.Enqueue(stations[i][1], -stations[i][1]);
						else break;
					}
				}
			} while (pq.Count > 0);

			return -1;
		}
	}
}