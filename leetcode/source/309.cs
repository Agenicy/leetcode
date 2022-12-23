using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q309
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MaxProfit(int[] prices)
		{
			int T_ik0_pre = 0, T_ik0 = 0, T_ik1 = int.MinValue;

			foreach (int price in prices)
			{
				int T_ik0_old = T_ik0;
				T_ik0 = Math.Max(T_ik0, T_ik1 + price);
				T_ik1 = Math.Max(T_ik1, T_ik0_pre - price);
				T_ik0_pre = T_ik0_old;
			}

			return T_ik0;
		}
	}
}