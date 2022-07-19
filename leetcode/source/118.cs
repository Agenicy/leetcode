using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q118
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.Generate(5));
			Log.Print("The answer should be [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]");
			Log.Print(solution.Generate(1));
			Log.Print("The answer should be [[1]]");
			Log.Print(solution.Generate(30));
		}
	}
	public class Solution
	{
		public IList<IList<int>> Generate(int numRows)
		{
			IList<IList<int>> ans = new List<IList<int>>();
			ans.Add(new List<int>(new[] { 1 }));
			for (int i = 1; i < numRows; i++)
			{
				var temp = new List<int>(ans[ans.Count - 1]);
				for (int x = 1; x < ans[ans.Count - 1].Count; x++)
				{
					temp[x] += ans[ans.Count - 1][x -1];
				}
				temp.Add(1);
				ans.Add(temp);
			}
			return ans;
		}
	}
}