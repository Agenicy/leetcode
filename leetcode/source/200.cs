using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q200
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.NumIslands(new char[][]{
				new[] { '1', '1', '1', '1', '0' },
				new[] { '1', '1', '0', '1', '0' },
				new[] { '1', '1', '0', '0', '0' },
				new[] { '0', '0', '0', '0', '0' }
			}));
			Log.Print(solution.NumIslands(new char[][]{
				new[]   {'1', '1', '0', '0', '0'},
				new[]   {'1', '1', '0', '0', '0'},
				new[]   {'0', '0', '1', '0', '0'},
				new[]   {'0', '0', '0', '1', '1'}
			}));
			Log.Print(solution.NumIslands(new char[][]{
				new[]   {'1', '1', '1'},
				new[]   {'0', '1', '0'},
				new[]   {'1', '1', '1'}
			}));
			Log.Print("The answer should be 1/ 3");
		}
	}
	public class Solution
	{
		public int NumIslands(char[][] grid)
		{

			int[,] hash = new int[grid.Length + 1, grid[0].Length + 1];
			int res = 0;
			Dictionary<int, int> hashTrans = new Dictionary<int, int>();
			for (int i = 1; i < hash.GetLength(0); i++)
			{
				for (int j = 1; j < hash.GetLength(1); j++)
				{
					if (grid[i - 1][j - 1] == '1')
					{
						if (hash[i - 1, j] == 0 && hash[i, j - 1] == 0)
						{
							hash[i, j] = i * 400 + j;
							res++;
						}
						else
						{
							int newhash1 = hash[i - 1, j];
							while (hashTrans.ContainsKey(newhash1)) newhash1 = hashTrans[newhash1];
							int newhash2 = hash[i, j - 1];
							while (hashTrans.ContainsKey(newhash2)) newhash2 = hashTrans[newhash2];

							if (newhash1 == 0 && newhash2 > 0)
							{
								hash[i, j] = newhash2;
							}
							else if ((newhash2 == 0 && newhash1 > 0) || (newhash1 == newhash2))
							{
								hash[i, j] = newhash1;
							}
							else
							{
								// hash not match
								/* 1 0 1
								 * 1 1 [1]
								 */
								hash[i, j] = i * 400 + j;

								hashTrans[newhash1] = hashTrans[newhash2] = hash[i, j];
								res--;
							}
						}
					}
				}

			}
			return res;
		}
	}
}