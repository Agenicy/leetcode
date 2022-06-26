using System;

namespace Q1423
{
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

			int max = int.MinValue;
			k++; // add axis, index plus 1
			int[] cardGraph = new int[k]; // in-place memory usage
			/*
			 * 12
			 * 8
			 * 4
			 * 6
			 */
			for (int j = 0; j < k; j++)
			{
				if (j == 0)
					cardGraph[j] = 0;
				else
					cardGraph[j] = cardPoints[j - 1] + cardGraph[j - 1];
				max = Math.Max(max, cardGraph[j]);
			}
			for (int j = k - 2, i = 1; j >= 0; j--, i++)
			{
				cardGraph[j] = cardGraph[j+1] - cardPoints[j] + cardPoints[cardPoints.Length - i];
				max = Math.Max(max, cardGraph[j]);
			}
			return max;
		}
	}
}
