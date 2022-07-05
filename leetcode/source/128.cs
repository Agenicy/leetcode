using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q128
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.LongestConsecutive(Parser.ParseArr1D("[1, 2, 0, 1]")));
			Console.WriteLine(solution.LongestConsecutive(Parser.ParseArr1D("[100,4,200,1,3,2]")));
			Console.WriteLine(solution.LongestConsecutive(Parser.ParseArr1D("[0,3,7,2,5,8,4,6,0,1]")));
			Console.WriteLine("The answer should be 3/ 4/ 9");
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
		public int LongestConsecutive(int[] nums)
		{
			if (nums.Length == 0)
				return 0;
			// works while no repeated numbers

			HashSet<int> set = new HashSet<int>(nums);
			Dictionary<int, int> map = new Dictionary<int, int>(); // len
			int mem;
			foreach (var num in set)
			{
				if (map.TryGetValue(num + 1, out mem))
				{
					map[num] = mem + 1;
				}
				else
				{
					map[num] = 1;
				}
				map.Remove(num + 1);
			}

			bool merged = true;
			while (merged)
			{
				merged = false;
				foreach (var k in map.Keys)
				{
					int next = k + map[k]; // num + len = next
					if (map.TryGetValue(next, out mem))
					{
						map[k] += map[next];
						map.Remove(next);
						merged = true;
					}
				}
			}
			return map.Values.Max();
		}
	}
}