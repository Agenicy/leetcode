using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1578
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
		public int MinCost(string colors, int[] neededTime)
		{
			Stack<HashSet<int>> needed = new();
			bool isAdding = false;
			for (int i = 1; i < colors.Length; i++)
			{
				if (colors[i] == colors[i - 1])
				{
					if (!isAdding)
					{
						isAdding = true;
						needed.Push(new());
					}
					needed.Peek().Add(i - 1);
					needed.Peek().Add(i);
				}
				else
				{
					isAdding = false;
				}
			}
			int sum = 0;
			while(needed.Count > 0)
			{
				var set = needed.Pop();
				sum += set.Select(x => neededTime[x]).Sum() - set.Select(x => neededTime[x]).Max();
			}
			return sum;
		}
	}
}