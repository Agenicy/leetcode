using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1239
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			//Log.Print(solution.MaxLength(new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" }));
			Log.Print(solution.MaxLength(new[] { "cha", "r", "act", "ers" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int MaxLength(IList<string> arr)
		{
			arr = arr.Where(x => x.Length == new HashSet<char>(x).Count).ToList();

			List<int> map = new(16);
			for (int i = 0; i < arr.Count; i++)
			{
				int p = 0;
				for (int j = 0; j < arr[i].Length; j++)
				{
					p |= 1 << (arr[i][j] -'a');
				}
				map.Add(p);
			}
			if (arr.Count == 0)
				return 0;

			int max = 0;
			void DFS(int i, int key, int length)
			{
				if (i == arr.Count) return;

				DFS(i + 1, key, length);
				if ((key & map[i]) == 0)
				{
					max = Math.Max(max, length += arr[i].Length);
					DFS(i + 1, key | map[i], length);
				}
			}
			DFS(0, 0, 0);
			return max;
		}
	}
}