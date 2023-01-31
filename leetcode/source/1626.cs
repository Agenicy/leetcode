using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace leetcode.Q1626
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.BestTeamScore(new[] { 1,98,2,100 }, new[] {1,1,2,2 }));
			Log.Print(solution.BestTeamScore(new[] { 1, 2, 3, 5 }, new[] { 8, 9, 10, 1 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int BestTeamScore(int[] scores, int[] ages)
		{
			var dp = new int[scores.Length];

			scores = Enumerable.Range(0, scores.Length)
			  .Select(i => (i, score: scores[i], age: ages[i]))
			  .OrderByDescending(a => a.age)
			  .ThenByDescending(a => a.score)
			  .Select(c => c.score)
			  .ToArray();

			for (var i = 0; i < scores.Length; i++)
			{
				var value = scores[i];

				for (var j = i - 1; j >= 0; j--)
					if (scores[j] >= scores[i])
						value = Math.Max(value, dp[j] + scores[i]);

				dp[i] = value;
			}

			return dp.Max();
		}
	}
}