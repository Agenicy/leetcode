using System;

namespace leetcode.Q4
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Console.WriteLine(solution.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }));
			Console.WriteLine(solution.FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 }));
			Console.WriteLine(solution.FindMedianSortedArrays(new int[0] { }, new[] { 1 }));
			Console.WriteLine("The answer should be 2.0/ 2.5/ 1");
		}
	}

	public class Solution
	{
		public double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			int a = 0, b = 0;
			int allNum = nums1.Length + nums2.Length;
			bool isTwoNumber = allNum % 2 == 0;
			int to = isTwoNumber ? allNum / 2 - 1 : allNum / 2;
			for (int i = 0; i < to; i++)
			{
				int numA = (a < nums1.Length) ? nums1[a] : int.MaxValue;
				int numB = (b < nums2.Length) ? nums2[b] : int.MaxValue;
				if (numA < numB)
					++a;
				else
					++b;
			}

			if (isTwoNumber)
			{
				float sum = 0;
				for (int i = 0; i < 2; i++)
				{
					int numA = (a < nums1.Length) ? nums1[a] : int.MaxValue;
					int numB = (b < nums2.Length) ? nums2[b] : int.MaxValue;
					sum += (numA < numB) ? nums1[a++] : nums2[b++];
				}
				return sum / 2;
			}
			else
			{
				float numA = (a < nums1.Length) ? nums1[a] : int.MaxValue;
				float numB = (b < nums2.Length) ? nums2[b] : int.MaxValue;
				if (numA < numB)
					return numA;
				else
					return numB;
			}
		}
	}
}
