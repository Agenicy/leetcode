using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace leetcode.Q2389
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.AnswerQueries(new[] {2,3,4,5 }, new[] { 1 }));
			Log.Print(solution.AnswerQueries(new[] { 4, 5, 2, 1 }, new[] { 3, 10, 21 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[] AnswerQueries(int[] nums, int[] queries)
		{
			Array.Sort(nums);
			List<int> prefix = new List<int>
			{
				nums[0]
			};
			for (int i = 1; i < nums.Length; i++)
			{
				prefix.Add(prefix[i - 1] + nums[i]);
			}
			int[] answer = new int[queries.Length];
			for (int id = 0; id < queries.Length; id++)
			{
				answer[id] = nums.Length;
				for (int i = 0; i < prefix.Count; i++)
				{
					if (prefix[i] > queries[id])
					{
						answer[id] = i;
						break;
					}
				}
			}
			return answer;
		}
	}
}