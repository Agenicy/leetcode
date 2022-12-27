using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace leetcode.Q2279
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MaximumBags(Parser.ParseArr1D("[2,3,4,5]"), Parser.ParseArr1D("[1,2,4,4]"), 2));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
		{
			PriorityQueue<int, int> pq = new(Enumerable.Range(0, capacity.Length).Select(x => capacity[x] - rocks[x]).Select(x=>(x, x)));
			int sum = 0;
			while(pq.Count > 0)
			{
				additionalRocks -= pq.Dequeue();
				if (additionalRocks < 0)
					break;
				else
					sum++;
			}
			return sum;
		}
	}
}