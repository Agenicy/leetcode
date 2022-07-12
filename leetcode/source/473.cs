using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q473
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.Makesquare(Parser.ParseArr1D("[7215807,6967211,5551998,6632092," +
				"2802439,821366,2465584,9415257,8663937,3976802,2850841,803069,2294462,8242205,9922998]")));
			Console.WriteLine(solution.Makesquare(Parser.ParseArr1D("[10,6,5,5,5,3,3,3,2,2,2,2]")));
			Console.WriteLine(solution.Makesquare(Parser.ParseArr1D("[5, 5, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3]")));
			Console.WriteLine(solution.Makesquare(Parser.ParseArr1D("[1,1,2,2,2]")));
			Console.WriteLine(solution.Makesquare(Parser.ParseArr1D("[3,3,3,3,4]")));
			Console.WriteLine("The answer should be t/ t/ t/ f");
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
		bool Backtracking(int id, ref int[] array, ref int[] sum, int match)
		{
			// if into end phase
			if (id == array.Length)
				return sum.All(x => x == match);

			// enumerate all
			for (int i = 0; i < 4; i++)
			{
				if (sum[i] + array[id] <= match)
				{
					sum[i] += array[id];
					if (Backtracking(id + 1, ref array, ref sum, match))
						return true;
					sum[i] -= array[id];
				}
			}
			return false;
		}
		public bool Makesquare(int[] matchsticks)
		{
			/* int[4] MQ(m, i) = MQ(m, i+1){ x=> x + m[i] for x in m }
			 * if Any(x=>x > sum) MQ = -1
			 * if All(x in m) == m[0] return true else return false
			 */
			int sum = matchsticks.Sum();
			if (sum % 4 != 0) return false;
			sum /= 4;
			Array.Sort(matchsticks, (a, b)=>b.CompareTo(a));
			var collection = new[] { 0, 0, 0, 0 };
			return Backtracking(0, ref matchsticks, ref collection, sum);
		}
	}
}