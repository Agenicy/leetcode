using System;
using System.Collections.Generic;

namespace leetcode.Q135
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[1,0,1,0,1]")));
			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[2,2]")));
			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[7,6,5,4,3]")));
			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[1,2,3,4,5]")));
			Console.WriteLine("The answer should be 8/ 2/ 15/ 15");

			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[1, 2, 87, 87, 87, 2, 1]")));
			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[1,3,2,2,1]")));
			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[1,0,2]")));
			Console.WriteLine(solution.Candy(Parser.ParseArr1D("[1,2,2]")));
			Console.WriteLine("The answer should be 13/ 7/ 5/ 4");
		}
	}
	public class Parser
	{
		public static int[] ParseArr1D(string input)
		{
			System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
			input = input.Replace(" ", "").Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 1)
			{
				list.Add(int.Parse(array[i]));
			}
			return list.ToArray();
		}
	}
	public class Solution
	{
		public int Candy(int[] ratings)
		{
			int n = ratings.Length;

			int candy = n, i = 1;
			while (i < n)
			{
				if (ratings[i] == ratings[i - 1])
				{
					i++;
					continue;
				}

				//For increasing slope
				int peak = 0;
				while (ratings[i] > ratings[i - 1])
				{
					peak++;
					candy += peak;
					i++;
					if (i == n) return candy;
				}

				//For decreasing slope
				int valley = 0;
				while (i < n && ratings[i] < ratings[i - 1])
				{
					valley++;
					candy += valley;
					i++;
				}
				candy -= Math.Min(peak, valley); //Keep only the higher peak
			}
			return candy;

		}

		int Sigma(int s) => s * (s + 1) / 2;
	}
}