using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q307
{
	public class Program
	{
		public static void Run()
		{
			NumArray numArray;
			numArray = new NumArray(new[] { -28, -39, 53, 65, 11, -56, -65, -39, -43, 97 });
			Log.Print(numArray.SumRange(5, 6));
			numArray.Update(9, 27);
			Log.Print(numArray.SumRange(2, 3));
			Log.Print(numArray.SumRange(6, 7));
			numArray.Update(1, -82);
			numArray.Update(3, -72);
			Log.Print(numArray.SumRange(3, 7));
			Log.Print(numArray.SumRange(1, 8));

			numArray = new NumArray(new[] { 9, -8 });
			numArray.Update(0, 3);
			Log.Print(numArray.SumRange(1, 1));
			Log.Print(numArray.SumRange(0, 1));
			numArray.Update(1, -3);
			Log.Print(numArray.SumRange(0, 1));
		}
	}
	/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */
	public class NumArray
	{
		int[] sums;
		int len;

		public NumArray(int[] nums)
		{
			len = nums.Length;
			sums = new int[len * 2]; // heap type
			Array.Copy(nums, 0, sums, len, len); // init
			for (int i = len - 1; i > 0; i--)
			{
				sums[i] = sums[i * 2] + sums[i * 2 + 1];
			}
		}

		public void Update(int index, int val)
		{
			index += len;
			sums[index] = val;
			while(index > 0)
			{
				int left = index, right = index;
				if (index % 2 == 0)
					right = index + 1;
				else
					left = index - 1;

				sums[index / 2] = sums[left] + sums[right];
				index /= 2;
			}
		}

		public int SumRange(int left, int right)
		{
			left += len;
			right += len;
			int sum = 0;
			while(left <= right)
			{
				if (left % 2 == 1)
					sum += sums[left++];
				if (right % 2 == 0)
					sum += sums[right--];
				left /= 2;
				right /= 2;
			}
			return sum;
		}
	}
}