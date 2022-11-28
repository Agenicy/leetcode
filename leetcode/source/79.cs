using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace leetcode.Q79
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.Exist(new[] { new[] { 'a' }, new[] { 'a' } }, "aaa"));
			Log.Print(solution.Exist(new[] { new[] { 'A', 'B', 'C', 'E' }, new[] { 'S', 'F', 'C', 'S' }, new[] { 'A', 'D', 'E', 'E' } }, "ABCCED"));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool Exist(char[][] board, string word)
		{
			int xm = board.Length - 1;
			int ym = board[0].Length - 1;
			IEnumerator<int[]> Next(int x, int y)
			{
				if (x > 0)
					yield return new[] { x - 1, y };
				if (x < xm)
					yield return new[] { x + 1, y };
				if (y > 0)
					yield return new[] { x, y - 1 };

				if (y < ym)
					yield return new[] { x, y + 1 };
			}

			BitArray SetMap(BitArray bitArray, int x, int y, bool state)
			{
				bitArray = new(bitArray);
				bitArray[x * 6 + y] = state;
				return bitArray;
			}
			bool GetMap(BitArray bitArray, int x, int y) => bitArray[x * 6 + y];

			bool DFS(int index, int x, int y, BitArray map)
			{
				if (index == word.Length)
					return true;

				map = SetMap(map, x, y, true);
				var ie = Next(x, y);
				while (ie.MoveNext())
				{
					int i = ie.Current[0];
					int j = ie.Current[1];
					if (!GetMap(map, i, j) & board[i][j] == word[index])
					{
						if (DFS(index + 1, i, j, map))
							return true;
					}
				}
				return false;
			}

			for (int i = 0; i <= xm; i++)
			{
				for (int j = 0; j <= ym; j++)
				{
					if (board[i][j] == word[0])
						if (DFS(1, i, j, new BitArray(36)))
							return true;
				}
			}
			return false;
		}
	}
}