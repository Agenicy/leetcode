using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace leetcode.Q990
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.EquationsPossible(new[] { "a==b", "e==c", "b==c", "a!=e" }));
			Log.Print(solution.EquationsPossible(new[] { "a==b", "b!=a" }));
			Log.Print(solution.EquationsPossible(new[] { "b==a", "a==b" }));
			Log.Print(solution.EquationsPossible(new[] { "a!=b", "b!=c", "c!=a" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool EquationsPossible(string[] equations)
		{
			int[] map = new int[26];
			var notEquals = equations
				.Where(line => line[1] == '!');

			if (notEquals.Count() == 0)
				return true;

			var equals = equations
				.Where(line => line[1] == '=');

			foreach (var pair in equals)
			{
				map[pair[0] - 'a'] |= 1 << pair[3] - 'a';
				map[pair[3] - 'a'] |= 1 << pair[0] - 'a';
			}

			int mapSize = 0;
			for (int i = 0; i < 26; i++)
			{
				if (map[i] != 0)
				{
					for (int row = mapSize; row < 26; row++) // find next pair in rows
						if ((map[i] & (1 << row)) != 0) // map[i][j] == true
							MakeGroup(row, mapSize);

					map[mapSize++] |= 1 << i; // in-place add group
				}
			}
			void MakeGroup(int row, int placeTo)
			{
				map[placeTo] |= 1 << row; // add into group

				for (int col = 0; col < 26; col++) // find next 1 in cols
				{
					if ((map[row] & (1 << col)) != 0) // map[i][j] == true
					{
						map[row] &= ~(1 << col); // clear map[i][j]
						if (col > placeTo)
							map[col] &= ~(1 << row); // clear map[j][i]
						if (col != placeTo)
							MakeGroup(col, placeTo);
					}
				}
			}
			foreach (var ne in notEquals)
			{
				if (ne[0] == ne[3])
					return false;

				for (int i = 0; i < mapSize; i++)
				{
					if ((map[i] & 1 << ne[0] - 'a') != 0)
						if ((map[i] & 1 << ne[3] - 'a') != 0)
							return false;
				}
			}
			return true;
		}
	}
}