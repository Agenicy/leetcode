using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q458
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.PoorPigs(1000, 15, 60));
			Log.Print(solution.PoorPigs(4, 15, 15));
			Log.Print(solution.PoorPigs(4, 15, 30));
			Log.Print("The answer should be 5/ 2/ 2");
		}
	}
	public class Solution
	{
		public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
		{
			int T = minutesToTest/minutesToDie;

			for (int i = 0; i < buckets; i++)
			{
				if (Math.Pow(T + 1, i) >= buckets) 
					return i;
			}
			return buckets;
		}
	}
}