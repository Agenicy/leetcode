using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q2136
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.EarliestFullBloom(Parser.ParseArr1D("[6,8,7,22,30,5,17,18]"), Parser.ParseArr1D("[30,15,1,21,5,13,5,11]")));
			Log.Print(solution.EarliestFullBloom(Parser.ParseArr1D("[1,4,3]"), Parser.ParseArr1D("[2,3,1]")));
			Log.Print(solution.EarliestFullBloom(Parser.ParseArr1D("[1,2,3,2]"), Parser.ParseArr1D("[2,1,2,1]")));
			Log.Print("The answer should be 114/ 9/ 9");
		}
	}
	public class Solution
	{
		public int EarliestFullBloom(int[] plantTime, int[] growTime)
		{
			var order = Enumerable.Range(0, plantTime.Length).OrderByDescending(x => growTime[x]);
			int max = 0;
			int plantLast = 0;
			foreach (var o in order)
			{
				plantLast += plantTime[o];
				max = Math.Max(plantLast + growTime[o], max);
			}
			return max;
		}
	}
}