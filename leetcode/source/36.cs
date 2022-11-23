using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q36
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool IsValidSudoku(char[][] board)
		{
			bool[,,] record = new bool[3, 9, 9]; // row/ col/ box, index, number
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					if (board[i][j] != '.')
					{
						int num = board[i][j] - '1';

						if (record[0, i, num])
							return false;
						record[0, i, num] = true;

						if (record[1, j, num])
							return false;
						record[1, j, num] = true;

						int ind_box = (i / 3) * 3 + j / 3;
						if (record[2, ind_box, num])
							return false;
						record[2, ind_box, num] = true;
					}
				}
			}
			return true;
		}
	}
}