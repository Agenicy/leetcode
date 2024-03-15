using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace leetcode.Q238
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			//Log.Print(solution.ProductExceptSelf(new int[] { 1, 2, 3, 4 }));
			Log.Print("The answer should be [24,12,8,6]");
			//Log.Print(solution.ProductExceptSelf(new int[] { -1, 1, 0, -3, 3 }));
			Log.Print("The answer should be [0,0,9,0,0] ");
			//Log.Print(solution.ProductExceptSelf(new int[] { 2, 2, 0, 2, 2, 0, 0, 2, 2 }));
			Log.Print(solution.ProductExceptSelf(Enumerable.Repeat(1, 50000).ToArray()));
		}
	}
	public class Solution
	{
		public int[] ProductExceptSelf(int[] nums)
		{
			if (nums.Length == 2)
			{
				int temp = nums[0];
				nums[0] = nums[1];
				nums[1] = temp;
				return nums;
			}

			int level = BitOperations.Log2((uint)nums.Length) + 1;
			int length = 1 << level;

			int[] heap = new int[length * 2];

			// init heap
			for (int i = length - 1; i >= 0; i--)
			{
				heap[i + length] = i >= nums.Length ? 1 : nums[i];
			}
			for (int i = length - 1; i > 1; i--)
			{
				heap[i] = heap[i * 2] * heap[i * 2 + 1];
			}

			for (int i = 1 << 2; i < length; i++)
			{
				heap[i ^ 1] *= heap[(i / 2) ^ 1];
			}

			for (int i = 0; i < nums.Length; i++)
			{
				nums[i] = heap[(i + length) ^ 1] * heap[(i + length) / 2 ^ 1];
			}


			return nums;
		}
	}
}