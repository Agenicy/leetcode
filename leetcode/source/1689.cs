using System;

namespace leetcode.Q1689
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MinPartitions("32"));
			Console.WriteLine(solution.MinPartitions("82734"));
			Console.WriteLine("The answer should be 3/ 8");
		}
	}
	public class Solution
	{
		public int MinPartitions(string n)
		{
			int max = 0;
			for (int i = 0; i < n.Length; i++)
			{
				max = Math.Max(max, n[i]-'0');
			}
			return max;
		}
	}
}