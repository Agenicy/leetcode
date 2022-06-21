#define Q1642

using System;
using System.Collections.Generic;

#if Q820
using Q820;
#elif Q1642
using Q1642;
#endif

namespace leetcode
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();
#if Q820
			Console.WriteLine(solution.MinimumLengthEncoding(new[] { "time", "me", "bell" }));
#elif Q1642
			/*Console.WriteLine(solution.FurthestBuilding(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1));
			Console.WriteLine(solution.FurthestBuilding(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2));
			Console.WriteLine(solution.FurthestBuilding(new[] { 14, 3, 19, 3 }, 17, 0));
			Console.WriteLine("The answer should be 4/ 7/ 3");*/

			string[] lines = System.IO.File.ReadAllLines("../../../testcase/1642/testcase1.txt");
			List<int> vs = new List<int>();
			foreach (var item in lines[0].Split(','))
			{
				vs.Add(int.Parse(item));
			}
			Console.WriteLine(solution.FurthestBuilding(vs.ToArray(), int.Parse(lines[1]), int.Parse(lines[2])));
			Console.WriteLine("The answer should be 72329");

#endif
		}
	}

}
