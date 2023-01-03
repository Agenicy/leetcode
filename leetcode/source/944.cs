using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q944
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
		public int MinDeletionSize(string[] strs)
		{
			int[] order = new int[strs[0].Length];
			int sum = 0;
			for (int j = 0; j < strs.Length; j++)
			{
				for (int i = 0; i < strs[0].Length; i++)
				{
					if (order[i] > 0)
					{
						if (strs[j][i] - 'a' < order[i])
						{
							sum++;
							order[i] = -1;
						}
						else
							order[i] = strs[j][i] - 'a';
					}
				}
			}
			return sum;
		}
	}
}