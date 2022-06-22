#define Q4

using System;
using System.Collections.Generic;
#if Q4
using Q4;
#elif Q215
using Q215;
#elif Q820
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
#if Q4
			Console.WriteLine(solution.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }));
			Console.WriteLine(solution.FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 }));
			Console.WriteLine(solution.FindMedianSortedArrays(new int[0] { }, new[] { 1 }));
			Console.WriteLine("The answer should be 2.0/ 2.5/ 1");
#elif Q215
			Console.WriteLine(solution.FindKthLargest(new[] { 3, 2, 1, 5, 6, 4 }, 2));
			Console.WriteLine(solution.FindKthLargest(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
			Console.WriteLine("The answer should be 5/ 4");
			Console.WriteLine(solution.FindKthLargest(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
			Console.WriteLine("The answer should be 4");
#elif Q820
			Console.WriteLine(solution.MinimumLengthEncoding(new[] { "time", "me", "bell" }));
#elif Q1642
			Console.WriteLine(solution.FurthestBuilding(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1));
			Console.WriteLine(solution.FurthestBuilding(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2));
			Console.WriteLine(solution.FurthestBuilding(new[] { 14, 3, 19, 3 }, 17, 0));
			Console.WriteLine(solution.FurthestBuilding(new[] { 2, 7, 9, 12}, 5, 1));
			Console.WriteLine(solution.FurthestBuilding(new[] { 1, 13, 1, 1, 13, 5, 11, 11 }, 10, 8));
			Console.WriteLine("The answer should be 4/ 7/ 3/ 3/ 7");

			
			string[] lines = System.IO.File.ReadAllLines("../../../testcase/1642/testcase1.txt");
			List<int> vs = new List<int>();
			foreach (var item in lines[0].Split(','))
			{
				vs.Add(int.Parse(item));
			}
			Console.WriteLine(solution.FurthestBuilding(vs.ToArray(), int.Parse(lines[1]), int.Parse(lines[2])));
			Console.WriteLine("The answer should be 72329");

			lines = System.IO.File.ReadAllLines("../../../testcase/1642/testcase2.txt");
			vs = new List<int>();
			foreach (var item in lines[0].Split(','))
			{
				vs.Add(int.Parse(item));
			}
			Console.WriteLine(solution.FurthestBuilding(vs.ToArray(), int.Parse(lines[1]), int.Parse(lines[2])));
			Console.WriteLine("The answer should be 589");
#endif
		}
	}

}
