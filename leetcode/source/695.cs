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

			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[0, 1, 1],[1, 1, 1]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[1,1,0],[1,1,1]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[1,1],[1,0]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[1,1,0,0,0],[1,1,0,0,0],[0,0,0,1,1],[0,0,0,1,1]]")));

			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]")));
			Console.WriteLine(solution.MaxAreaOfIsland(Parser.ParseArr2D("[[0,0,0,0,0,0,0,0]]")));

			Console.WriteLine("The answer should be 5/ 5/ 3/ 4/ 6/ 0");
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
			Dictionary<int, int> hashTrans = new Dictionary<int, int>();
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
						else
						{
							int newhash1 = hash[i - 1, j];
							while (hashTrans.ContainsKey(newhash1)) newhash1 = hashTrans[newhash1];
							int newhash2 = hash[i, j - 1];
							while (hashTrans.ContainsKey(newhash2)) newhash2 = hashTrans[newhash2];

							if (newhash1 == 0 && newhash2 > 0)
							{
								hash[i, j] = newhash2;
								map[newhash2]++;
							}
							else if ((newhash2 == 0 && newhash1 > 0) || (newhash1 == newhash2))
							{
								hash[i, j] = newhash1;
								map[newhash1]++;
							}
							else
							{
								// hash not match
								/* 1 0 1
								 * 1 1 [1]
								 */
								hash[i, j] = i * 200 + j;
								map[hash[i, j]] = map[newhash1] + map[newhash2] + 1;

								hashTrans[newhash1] = hashTrans[newhash2] = hash[i, j];
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