using System;

namespace leetcode.Q665
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[4,2,3]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[4,2,1]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[3,4,2,3]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[5, 7, 1, 8]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[-1, 4, 2, 3]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[1, 4,1,2]")));
			Console.WriteLine("The answer should be t/ f/ f/ t/ t/ t");
		}
	}
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
			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i - 1] > nums[i] )
				{
					if (isChanged)
						return false;
					else
					{
						isChanged = true;
						if (i == 1 || nums[i - 2 ] <= nums[i])
							nums[i-1] = nums[i];
						else
							nums[i] = nums[i-1];
					}
				}
			}
			return true;
		}
	}
}
