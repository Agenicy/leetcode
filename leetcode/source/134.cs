using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q134
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
		public int CanCompleteCircuit(int[] gas, int[] cost)
		{
			int start = -1;
			int sum = -1;
			int gasCount = 0, costCount = 0; ;
			for (int i = 0; i < gas.Length; i++)
			{
				gasCount += gas[i];
				costCount += cost[i];
				gas[i] -= cost[i];
				if (sum < 0)
				{
					if (gas[i] >= 0)
					{
						start = i;
						sum = gas[i];
					}
					else
						start = -1;
				}
				else
				{
					sum += gas[i];
				}
			}
			if (gasCount < costCount)
				return -1;
			return start;
		}
	}
}