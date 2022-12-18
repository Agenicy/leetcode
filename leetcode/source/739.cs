using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q739
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
		public int[] DailyTemperatures(int[] temperatures)
		{
			Stack<int> stack = new();
			for (int i = 0; i < temperatures.Length; i++)
			{
				while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
				{
					int day = stack.Pop();
					temperatures[day] = i - day;
				}
				stack.Push(i);
			}
			while (stack.Count > 0)
				temperatures[stack.Pop()] = 0;
			return temperatures;
		}
	}
}