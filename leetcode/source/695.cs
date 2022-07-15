using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q695
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[1,1,0],[1,1,1]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[1,1],[1,0]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[1,1,0,0,0],[1,1,0,0,0],[0,0,0,1,1],[0,0,0,1,1]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[0,0,0,0,0,0,0,0]]")));

			Console.WriteLine("The answer should be 5/ 3/ 4/ 6/ 0");
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
		public static int[][] ParseArr2D(string input)
		{
			List<int[]> ret = new List<int[]>();
			input = input.Replace(" ", "");
			input = input.Substring(2, input.Length - 3);
			foreach (var s in input.Replace("],", "").Replace("]", "").Split("["))
			{
				string[] array = s.Split(',');
				var list = new List<int>(Enumerable.Range(0, array.Length).Select(x => int.Parse(array[x])));
				ret.Add(list.ToArray());
			}
			return ret.ToArray();
		}
	}
	public class Solution
	{
		public int MaxAreaOfIsland(int[][] grid)
		{
			int[,] hash = new int[grid.Length + 1, grid[0].Length + 1];
			Dictionary<int, int> map = new Dictionary<int, int>();
			for (int i = 1; i < hash.GetLength(0); i++)
			{
				for (int j = 1; j < hash.GetLength(1); j++)
				{
					if (grid[i - 1][j - 1] == 1)
					{
						if (hash[i - 1, j] == 0 && hash[i, j - 1] == 0)
						{
							hash[i, j] = i * 200 + j;
							map[hash[i, j]] = 1;
						}
						else if (hash[i - 1, j] == 0 && hash[i, j - 1] > 0)
						{
							hash[i, j] = hash[i, j - 1];
							map[hash[i, j]]++;
						}
						else if (hash[i, j - 1] == 0 && hash[i - 1, j] > 0)
						{
							hash[i, j] = hash[i - 1, j];
							map[hash[i, j]]++;
						}
						else if (hash[i - 1, j] == hash[i, j - 1])
						{
							hash[i, j] = hash[i - 1, j];
							map[hash[i - 1, j]]++;
						}
						else
						{
							// hash not match
							/* 1 0 1
							 * 1 1 [1]
							 */
							hash[i, j] = i * 200 + j;
							map[hash[i, j]] = map[hash[i - 1, j]] + map[hash[i, j - 1]] + 1;
							int last1 = hash[i, j - 1];
							int last2 = hash[i - 1, j];
							for (int x = 1; x <= i; x++)
							{
								for (int y = 1; y < hash.GetLength(1); y++)
								{
									if (hash[x, y] == last1
									|| hash[x, y] == last2)
									{
										hash[x, y] = hash[i, j];
									}
								}
							}
						}
					}
				}

			}
			int max = (map.Count > 0) ? map.Keys.Max(x => map[x]) : 0;
			return max;
		}
	}
}