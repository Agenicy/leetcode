using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q609
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
		public IList<IList<string>> FindDuplicate(string[] paths)
		{
			List<IList<string>> result = new();
			Dictionary<int, List<string>> map = new();

			foreach (var p in paths)
			{
				string[] res = p.Split(' ');
				string folder = res[0];
				for (int i = 1; i < res.Length; i++)
				{
					string[] file = res[i].Split('(');
					string filename = file[0];
					int fileData = file[1].GetHashCode();
					if (!map.ContainsKey(fileData))
						map[fileData] = new List<string>();
					map[fileData].Add(folder + '/' + filename);
				}
			}
			foreach (var k in map.Keys)
			{
				if (map[k].Count < 2)
					continue;
				List<string> n = new();
				foreach (var v in map[k])
				{
					n.Add(v);
				}
				result.Add(n);
			}
			return result;
		}
	}
}