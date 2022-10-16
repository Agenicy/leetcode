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

			int hidden = jobDifficulty.Length - d;
			(int, int)[][] utility = // (sum, max)
				Enumerable.Range(0, jobDifficulty.Length)
				.Select(x => Enumerable.Repeat((-1, -1), hidden + 1).ToArray()).ToArray();


			/*
			 * DP(ind, left) = (left <= 0)? Utility(x) + DP(x+1, 0):
			 *		Min( Utility(x) + DP(x+1, hidden-1), DP(x+1, hidden) )
			 * 
			 * Utility(ind) = IsHidden(ind)? Min( Utility(ind) , Utility(ind-1) ): Utility(ind)
			 */
			utility[0][0] = (jobDifficulty[0], jobDifficulty[0]);

			int Util(int ind, int isHidden)
			{
				if (ind < 0)
					return 0;
				else if (isHidden > ind)
					return short.MaxValue;
				else if (utility[ind][isHidden].Item1 != -1)
					return utility[ind][isHidden].Item1;
				else if (isHidden == 0) // not hid
				{
					utility[ind][isHidden].Item2 = jobDifficulty[ind];
					return utility[ind][isHidden].Item1 = jobDifficulty[ind] + Util(ind - 1, 0);
				}

				// count value = take or not take
				int take = Util(ind - 1, isHidden) + jobDifficulty[ind];

				int hide = Util(ind - 1, isHidden - 1);
				// hide
				int bias = jobDifficulty[ind] - utility[ind - 1][isHidden - 1].Item2;
				if (bias > 0)
				{
					utility[ind][isHidden].Item2 = jobDifficulty[ind];
					hide += bias;
				}
				else
				{
					utility[ind][isHidden].Item2 = utility[ind - 1][isHidden - 1].Item2;
				}

				if (take < hide)
				{
					utility[ind][isHidden].Item2 = jobDifficulty[ind];
					return utility[ind][isHidden].Item1 = take;
				}
				else
				{
					return utility[ind][isHidden].Item1 = hide;
				}
				
			}

			int ret = Util(jobDifficulty.Length-1, hidden);
			return ret;

		}
	}
}