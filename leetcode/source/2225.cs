using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q2225
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindWinners(Parser.ParseArr2D("[[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public IList<IList<int>> FindWinners(int[][] matches)
		{
			SortedSet<int> players = new();
			IList<IList<int>> winners = new List<IList<int>>();
			winners.Add(new List<int>());
			winners.Add(new List<int>());
			SortedDictionary<int, int> keyValuePairs = new();
			for (int i = 0; i < matches.Length; i++)
			{
				players.Add(matches[i][0]);
				players.Add(matches[i][1]);

				if (!keyValuePairs.ContainsKey(matches[i][1]))
					keyValuePairs[matches[i][1]] = 1;
				else
					keyValuePairs[matches[i][1]] += 1;
			}
			foreach (var i in players)
			{
				if (!keyValuePairs.ContainsKey(i))
					winners[0].Add(i);
				else if (keyValuePairs[i] == 1)
					winners[1].Add(i);
			}
			return winners;
		}
	}
}