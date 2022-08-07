using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1220
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.CountVowelPermutation(1));
			Log.Print(solution.CountVowelPermutation(2));
			Log.Print(solution.CountVowelPermutation(5));
			Log.Print("The answer should be 5/ 10/ 68");
		}
	}
	public class Solution
	{
		const int mod = (int)(1e9 + 7);
		/*
		static readonly int[] NextCount = new int[] { 3, 2, 2, 1, 2 };
		static readonly int[][] NextType = new[]
		{
			new[]{ 1,2,4},
			new[]{ 0,2},
			new[]{ 1,3},
			new[]{ 2},
			new[]{ 2,3}
		};
		static readonly int[,] Next = new[,]
		{
			{0,1,1,0,1 },
			{1,0,1,0,0 },
			{0,1,0,1,0 },
			{0,0,1,0,0 },
			{0,0,1,1,0 }
		};*/

		int[] MatMul(int[] now)
		{
			int[] next = new int[5];
			next[0] = (now[1] + (now[2] + now[4]) % mod) %mod;
			next[1] = (now[0] + now[2]) % mod;
			next[2] = (now[1] + now[3]) % mod;
			next[3] = (now[2]) % mod;
			next[4] = (now[2] + now[3]) % mod;
			return next;
		}

		public int CountVowelPermutation(int n)
		{
			int[] count = new int[] { 1, 1, 1, 1, 1 };

			for (int i = 1; i < n; i++)
				count = MatMul(count);

			int sum = 0;
			for (int i = 0; i < 5; i++)
				sum = (sum + count[i]) % mod;

			return sum;
		}
	}
}