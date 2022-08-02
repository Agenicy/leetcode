using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q378
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.KthSmallest(Parser.ParseArr2D("[[1,5,9],[10,11,13],[12,13,15]]"), 8));
			Log.Print("The answer should be 13");
		}
	}
	public class Solution
	{
		public int KthSmallest(int[][] matrix, int k)
		{
			int n = matrix.Length;

			PriorityQueue<(int, int), int> priorityQueue = new();

			int GetPriority(int place, int ind) => matrix[place][ind];

			for (int i = 0; i < n; i++)
			{
				priorityQueue.Enqueue((i, 0), GetPriority(i, 0));
			}
			int place=0; int ind=0;
			for (int i = 0; i < k; i++)
			{
				(place, ind) = priorityQueue.Dequeue();
				if (ind+1 < n)
					priorityQueue.Enqueue((place, ind + 1), GetPriority(place, ind + 1));
			}
			return matrix[place][ind];
		}
	}
}