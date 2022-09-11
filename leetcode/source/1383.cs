using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace leetcode.Q1383
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MaxPerformance(3, Parser.ParseArr1D("[2,8,2]"), Parser.ParseArr1D("[2,7,1]"), 2));
			Log.Print(solution.MaxPerformance(6, Parser.ParseArr1D("[2,10,3,1,5,8]"), Parser.ParseArr1D("[5,4,3,9,7,2]"), 2));
			Log.Print("The answer should be 56/ 60/ ");
		}
	}
	public class Solution
	{
		const int mod = (int)1e9 + 7;

		public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
		{
			(int, int)[] wait = Enumerable.Range(0, n).Select(x => (speed[x], efficiency[x])).OrderByDescending(i => i.Item2).ThenBy(i => i.Item1).ToArray();

			long maxValue = int.MinValue, teamSpd = 0;

			PriorityQueue<int, int> pq = new();

			for (int i = 0; i < n; i++)
			{
				if (pq.Count >= k)
				{
					teamSpd = teamSpd + wait[i].Item1 - pq.Peek();
					pq.EnqueueDequeue(wait[i].Item1, wait[i].Item1);
				}
				else
				{
					teamSpd = teamSpd + wait[i].Item1;
					pq.Enqueue(wait[i].Item1, wait[i].Item1);
				}

				maxValue = Math.Max(maxValue, teamSpd * wait[i].Item2);
			}

			return (int)(maxValue % mod);
		}
	}
}