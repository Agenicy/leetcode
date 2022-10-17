using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json.Serialization;

namespace leetcode.Q1335
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MinDifficulty(Parser.ParseArr1D("[143,446,351,170,117,963,785,76,139,772,452,743,23,767,564,872,922,532,957,945,203,615,843,909,458,320,290,235,174,814,414,669,422,769,781,721,523,94,100,464,484,562,941]"), 5));
			Log.Print(solution.MinDifficulty(Parser.ParseArr1D("[7,1,7,1,7,1]"), 3));
			Log.Print(solution.MinDifficulty(Parser.ParseArr1D("[6,5,4,3,2,1]"), 2));
			Log.Print(solution.MinDifficulty(Parser.ParseArr1D("[9,9,9]"), 4));
			Log.Print(solution.MinDifficulty(Parser.ParseArr1D("[1,1,1]"), 3));
			Log.Print("The answer should be 1839/ 15/ 7/ -1/ 3");
		}
	}
	public class Solution
	{
		public int MinDifficulty(int[] jobDifficulty, int d)
		{
			if (d > jobDifficulty.Length) return -1;
			else if (d == jobDifficulty.Length) return jobDifficulty.Sum();

			/*
			 *	DFS(param int[] jobs)
			 *		int group = foreach i in range(len(jobs))
			 *			return Max(x => jobs[x]) + DFS(group+1: jobs_left)
			 */
			int[][] max = 
				Enumerable.Range(0, jobDifficulty.Length)
				.Select(x=>Enumerable.Repeat((int)short.MaxValue, d).ToArray()).ToArray();

			max[0][0] = jobDifficulty[0];
			for (int i = 1; i < jobDifficulty.Length; i++)
			{
				max[i][0] = Math.Max(jobDifficulty[i], max[i - 1][0]);
			}

			for (int i = 1; i < jobDifficulty.Length; i++) // row
			{
				for (int j = 1; j < Math.Min(i + 1, d); j++) // col
				{
					int max_now = jobDifficulty[i];
					for (int k = i - 1; k >= 0; k--)
					{
						max[i][j] = Math.Min(max[i][j], max_now + max[k][j - 1]);
						max_now = Math.Max(jobDifficulty[k], max_now);
					}
				}
			}
			return max[jobDifficulty.Length - 1][d - 1];
		}
	}
}