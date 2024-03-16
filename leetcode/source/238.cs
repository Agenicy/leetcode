using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace leetcode.Q238
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Log.Print(solution.ProductExceptSelf(new int[] { 1, 2, 3, 4 }));
			Log.Print("The answer should be [24,12,8,6]");
			Log.Print(solution.ProductExceptSelf(new int[] { -1, 1, 0, -3, 3 }));
			Log.Print("The answer should be [0,0,9,0,0] ");
			Log.Print(solution.ProductExceptSelf(new int[] { 2, 2, 0, 2, 2, 0, 0, 2, 2 }));
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

			int length = 1;
			while (length < nums.Length)
			{
				length = length << 1;
			}

			int[] heap = new int[length];
			Array.Fill(heap, 1);

			// init heap
			
			for (int i = 0; i < nums.Length; i++)
			{
				// level 1
				heap[(i + length) / 2] *= nums[i];
			}

			for (int i = length / 2 - 1; i > 1; i--)
			{
				// level 2+
				heap[i] = heap[i * 2] * heap[i * 2 + 1];
			}

			for (int i = 1 << 2; i < length; i++)
			{
				heap[i ^ 1] *= heap[(i / 2) ^ 1];
			}

			for (int i = 0; i < nums.Length; i += 2)
			{
				int temp = 1;
				if (i + 1 < nums.Length)
				{
					temp = nums[i + 1];
					nums[i + 1] = nums[i] * heap[(i + 1 + length) / 2 ^ 1];
				}
				nums[i] = temp * heap[(i + length) / 2 ^ 1];
			}
			return nums;
		}
	}
}