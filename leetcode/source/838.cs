using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q838
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.PushDominoes("RR.L"));
			Log.Print(solution.PushDominoes(".L.R...LR..L.."));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public string PushDominoes(string dominoes)
		{
			int[] L = new int[dominoes.Length];
			int[] R = new int[dominoes.Length];

			int sum = 0;
			for (int i = 0; i < dominoes.Length; i++)
			{
				switch (dominoes[i])
				{
					case '.':
						R[i] = sum > 0 ? --sum : 0;
						break;
					case 'L':
						R[i] = sum = 0;
						break;
					case 'R':
						R[i] = sum = int.MaxValue;
						break;
				}
			}
			for (int i = dominoes.Length-1; i >=0 ; i--)
			{
				switch (dominoes[i])
				{
					case '.':
						L[i] = sum > 0 ? --sum : 0;
						break;
					case 'L':
						L[i] = sum = int.MaxValue;
						break;
					case 'R':
						L[i] = sum = 0;
						break;
				}
			}
			char[] sb = new char[dominoes.Length];
			for (int i = 0; i < dominoes.Length; i++)
			{
				if (L[i] == R[i])
					sb[i] = '.';
				else if (L[i] > R[i])
					sb[i] = 'L';
				else if (L[i] < R[i])
					sb[i] = 'R';
			}
			return new(sb);
		}
	}
}