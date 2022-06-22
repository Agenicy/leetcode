using System;

namespace Q4
{
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
