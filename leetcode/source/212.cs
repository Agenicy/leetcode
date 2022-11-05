using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q212
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindWords(new char[2][] { new[] { 'a', 'a' }, new[] { 'a', 'a' } }, new[] { "aaaaa" }));
			Log.Print(solution.FindWords(new char[4][] { new[] { 'o', 'a', 'b', 'n' }, new[] { 'o', 't', 'a', 'e' }, new[] { 'a', 'h', 'k', 'r' }, new[] { 'a', 'f', 'l', 'v' } }, new[] { "oa", "oaa" }));
			Log.Print(solution.FindWords(new char[1][] { new[] { 'a' } }, new[] { "a" }));
			Log.Print(solution.FindWords(new char[4][] { new[] { 'o', 'a', 'a', 'n' }, new[] { 'e', 't', 'a', 'e' }, new[] { 'i', 'h', 'k', 'r' }, new[] { 'i', 'f', 'l', 'v' } }, new[] { "oath", "pea", "eat", "rain" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public IList<string> FindWords(char[][] board, string[] words)
		{
			Dictionary<char, List<int[]>> dict = new();
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					if (!dict.ContainsKey(board[i][j]))
						dict[board[i][j]] = new List<int[]>();
					dict[board[i][j]].Add(new[] { i, j, 0 });
				}
			}
			List<string> ret = new();
			foreach (var w in words)
			{
				string word = w;
				if (word.Any(x => !dict.ContainsKey(x))) continue;
				if (word.Length == 1)
					ret.Add(word);
				else
				{
					bool isReversed = false;
					if (word[0] == word[1])
					{
						char[] charArray = word.ToCharArray();
						Array.Reverse(charArray);
						word = new string(charArray);
						isReversed = true;
					}
					bool isAdded = false;
					Stack<(int[], BitArray)> q = new();
					foreach (var vs in dict[word[0]])
					{
						BitArray btary = new BitArray(144);
						btary.Set(12 * vs[0] + vs[1], true);
						q.Push((vs, btary));

						if (isAdded) break;
					} 
					while (q.Count > 0)
					{
						(int[] next, BitArray bt) = q.Pop();
						int i = next[0]; int j = next[1]; int ind = next[2];
						foreach ((int xb, int yb) in new[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
						{

							int x = i + xb; int y = j + yb;
							if (0 <= x & x < board.Length & 0 <= y & y < board[0].Length)
							{
								if (bt.Get(12 * x + y)) continue;
								if (board[x][y] == word[ind + 1])
								{
									if (ind + 1 == word.Length - 1)
									{
										isAdded = true;
										if(isReversed)
										{
											char[] charArray = word.ToCharArray();
											Array.Reverse(charArray);
											word = new string(charArray);
										}
										ret.Add(word);
										break;
									}
									else
									{
										BitArray copy = new(bt);
										copy.Set(12 * x + y, true);
										q.Push((new[] { x, y, ind + 1 }, copy));
									}
								}
							}
						}
						if (isAdded) break;
					}
				}

			}
			return ret;
		}
	}
}