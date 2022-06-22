using System;
using System.Collections.Generic;

namespace Q215
{
	public class Solution
	{
		/// <summary>
		/// 1 <= k <= nums.length <= 1e4
		/// -1e4 <= nums[i] <= 1e4
		/// </summary>
		public int FindKthLargest(int[] nums, int k)
		{
			// all the nums will be add with a 1e5 to make positive
			// [20000-19900), [19900-19800), ...

			const int boxSize = 100;
			const int bias = 10000;
			const int maxValue = 10000;
			const int size = (maxValue + bias) / boxSize;

			static int GetBoxInd(int value) => (maxValue - value) / boxSize; // get value with bias

			List<int>[] nodes = new List<int>[size];

			for (int i = 0; i < size; i++)
			{
				// create box
				nodes[i] = new List<int>();
			}

			foreach (var num in nums)
			{
				// add into bucket
				int ind = GetBoxInd(num);
				nodes[ind].Add(num);
			}

			int sum = 0;
			for (int i = 0; i < size; i++)
			{
				// get answer
				if ((sum + nodes[i].Count) >= k)
				{
					int ind = k - sum;

					nodes[i].Sort((a, b) => b.CompareTo(a));
					return nodes[i][ind - 1];
				}

				sum += nodes[i].Count;
			}
			return int.MaxValue;
		}
	}
}
