using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q307
{
	public class Program
	{
		public static void Run()
		{
			NumArray numArray = new NumArray(new[] { -28, -39, 53, 65, 11, -56, -65, -39, -43, 97 });
			Log.Print(numArray.SumRange(5, 6));
			numArray.Update(9, 27);
			Log.Print(numArray.SumRange(2, 3));
			Log.Print(numArray.SumRange(6, 7));

			numArray.Update(1, -82);
			numArray.Update(3, -72);
			Log.Print(numArray.SumRange(3, 7));
			Log.Print(numArray.SumRange(1, 8));
			/*NumArray numArray = new NumArray(new[] { 9, -8 });
			numArray.Update(0, 3);
			Log.Print(numArray.SumRange(1, 1));
			Log.Print(numArray.SumRange(0, 1));
			numArray.Update(1, -3);
			Log.Print(numArray.SumRange(0, 1));*/
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
		int[] nums;
		int[] sums;
		int dirty = 0;
		Dictionary<int, int> dict = new();

		public NumArray(int[] nums)
		{
			this.nums = nums;
			sums = new int[nums.Length];
			UpdateAfter(0, nums.Length);
		}

		public void UpdateAfter(int start, int end)
		{
			if (start == 0)
			{
				sums[0] = nums[0];
				start = 1;
			}
			for (int i = start; i < end; i++)
			{
				sums[i] = sums[i - 1] + nums[i];
			}
			dirty = end;
		}

		public void Update(int index, int val)
		{
			if (dict.ContainsKey(index))
				dict[index] += val - nums[index];
			else
				dict[index] = val - nums[index];
			nums[index] = val;
			dirty = Math.Min(dirty, index);
		}

		public int SumRange(int left, int right)
		{
			if (left == right)
				return nums[left];

			int bias = 0;
			if (right >= dirty)
			{
				if (dict.Keys.Count < 40)
				{
					foreach (var k in dict.Keys)
					{
						if (k >= left && k <= right)
							bias += dict[k];
					}
				}
				else
				{
					UpdateAfter(dirty, nums.Length);
					dict = new();
				}
			}
			left = left == 0 ? 0 : sums[left - 1];
			return sums[right] - left + bias;
		}
	}
}