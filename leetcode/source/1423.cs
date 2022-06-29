using System;

namespace leetcode.Q1423
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Console.WriteLine(solution.MaxScore(Parser.Parse("[1,2,3,4,5,6,1]"), 3));
			Console.WriteLine(solution.MaxScore(Parser.Parse("[2,2,2]"), 2));
			Console.WriteLine(solution.MaxScore(Parser.Parse("[9,7,7,9,7,7,9]"), 7));
			Console.WriteLine(solution.MaxScore(Parser.Parse("[100, 40, 17, 9, 73, 75]"), 3));
			Console.WriteLine("The answer should be 12/ 4/ 55/ 248");
		}
	}
	public class Parser
	{
		public static int[] Parse(string input)
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
		public int MaxScore(int[] cardPoints, int k)
		{
			/*
			 * 0 1 7 12
			 * 1 2 8
			 * 3 4
			 * 6
			 */
			if (k == 0)
				return 0;
			if (k == cardPoints.Length)
			{
				int s = 0;
				for (int i = 0; i < cardPoints.Length; i++)
				{
					s += cardPoints[i];
				}
				return s;
			}

			int mem = 0; // in-place memory usage
			/*
			 * 12
			 * 8
			 * 4
			 * 6
			 */
			for (int j = 0; j < k; j++)
			{
				mem += cardPoints[j];
			}
			int max = mem;
			for (int j = k - 1, i = 1; j >= 0; j--, i++)
			{
				mem = mem - cardPoints[j] + cardPoints[cardPoints.Length - i];
				max = Math.Max(max, mem);
			}
			return max;
		}
	}
}
