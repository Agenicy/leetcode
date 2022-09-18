using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q42
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.Trap(Parser.ParseArr1D("[0,1,0,2,1,0,1,3,2,1,2,1]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int Trap(int[] height)
		{
			if (height.Length <= 2)
				return 0;

			int front = -1, rear = height.Length;
			int sum = 0;
			int f_max = 0, r_max = 0;

			while (front < rear)
			{
				if (f_max < r_max)
				{
					front++;

					sum += Math.Max(f_max - height[front], 0);
					f_max = Math.Max(f_max, height[front]);

				}
				else
				{
					rear--;
					sum += Math.Max(r_max - height[rear], 0);
					r_max = Math.Max(r_max, height[rear]);
				}
			}
			return sum;
		}
	}
}