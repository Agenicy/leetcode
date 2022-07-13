using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q11
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MaxArea(Parser.ParseArr1D("[2, 3, 4, 5, 18, 17, 6]")));
			Console.WriteLine(solution.MaxArea(Parser.ParseArr1D("[1,8,6,2,5,4,8,3,7]")));
			Console.WriteLine(solution.MaxArea(Parser.ParseArr1D("[1,1]")));
			Console.WriteLine("The answer should be 17/ 49/ 1");
		}
	}
	public class Parser
	{
		public static int[] ParseArr1D(string input)
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
		public int MaxArea(int[] height)
		{
			int left = 0, right = height.Length - 1;
			int lq = (right - left) * Math.Min(height[left], height[right]);
			while(left < right)
			{
				var lqNext = (right - left) * Math.Min(height[left], height[right]);
				lq = Math.Max(lq, lqNext);
				if (height[left] < height[right])
					left++;
				else
					right--;
			}
			return lq;
		}
	}
}