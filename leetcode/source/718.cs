using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace leetcode.Q718
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindLength(Parser.ParseArr1D("[1,2,3,2,1]"), Parser.ParseArr1D("[3,2,1,4,7]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int FindLength(int[] nums1, int[] nums2)
		{
			int[,] dp = new int[nums1.Length, nums2.Length];

			int max = int.MinValue;
			for (int i = 0; i < nums1.Length; i++)
			{
				for (int j = 0; j < nums2.Length; j++)
				{
					if (nums1[i] == nums2[j])
					{
						if (i > 0 && j > 0)
						{
							dp[i, j] = dp[i-1, j - 1] + 1;
						}
						else
						{
							dp[i, j] = 1;
						}
						max = Math.Max(max, dp[i, j]);
					}
					else
					{
						dp[i, j] = 0;
					}
				}
			}
			return max;
		}
	}
}