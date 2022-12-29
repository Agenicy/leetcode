using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1962
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MinStoneSum(new[] { 5, 4, 9 }, 2));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{

		public int MinStoneSum(int[] piles, int k)
		{
			int sum = 0;
			PriorityQueue<int, int> removed = new();

			void Loop(int id)
			{
				int half = piles[id];
				for (int i = 0; i < k; i++)
				{
					int left = half & 1; // %=2
					half >>= 1;

					if (removed.Count < k)
					{
						removed.Enqueue(half, half);
					}
					else if (removed.Peek() < half)
					{
						sum += removed.Dequeue();
						removed.Enqueue(half, half);
					}
					else
					{
						half = half << 1 | left;
						break;
					}
					half += left;
				}
				sum += half;
			}
			// 2 / 1+2
			// 5 / 2+2
			// 12 / 4+2

			for (int i = 0; i < piles.Length; i++)
			{
				Loop(i);
			}

			return sum;
		}
	}
}