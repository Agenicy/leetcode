using System;

namespace Q665
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
		public bool CheckPossibility(int[] nums)
		{
			bool isChanged = false;
			for (int i = 0; i < nums.Length; i++)
			{
				int last = i >= 1 ? nums[i - 1] : int.MinValue;
				if (last > nums[i] || (i < nums.Length - 1 && nums[i] > nums[i+1]))
				{
					if (isChanged)
						return false;
					else
					{
						isChanged = true;
						if (i < nums.Length -1 && nums[i + 1] < last)
							nums[i+1] = nums[i];
						else
							nums[i] = last;
					}
				}
			}
			return true;
		}
	}
}
