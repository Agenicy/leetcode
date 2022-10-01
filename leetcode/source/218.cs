using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q218
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.GetSkyline(Parser.ParseArr2D("[[22638,125612,510012],[25500,184131,186209],[25773,659996,327819],[28260,973355,751082],[39852,418706,677469],[75167,97032,958756],[81451,108159,841036],[95346,264893,629976],[124106,460546,442029],[130170,856130,996190],[130603,456824,78879]]")));
			Log.Print(solution.GetSkyline(Parser.ParseArr2D("[[0,5,7],[5,10,7],[5,10,12],[10,15,7],[15,20,7],[15,20,12],[20,25,7]]")));
			Log.Print("The answer should be [[0,7],[5,12],[10,7],[15,12],[20,7],[25,0]]");
			Log.Print(solution.GetSkyline(Parser.ParseArr2D("[[1,2,3],[1,3,2],[1,4,1]]")));
			Log.Print("The answer should be [[1,3],[2,2], [3,1], [4,0]]");
			Log.Print(solution.GetSkyline(Parser.ParseArr2D("[[1,2,1],[1,2,2],[1,2,3]]")));
			Log.Print("The answer should be [[1,3],[2,0]]");
			Log.Print(solution.GetSkyline(Parser.ParseArr2D("[[0,2147483647,2147483647]]")));
			Log.Print("The answer should be [[0,2147483647],[2147483647,0]]");
			Log.Print(solution.GetSkyline(Parser.ParseArr2D("[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]")));
			Log.Print("The answer should be [[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]]");
			Log.Print(solution.GetSkyline(Parser.ParseArr2D("[[0,2,3],[2,5,3]]")));
			Log.Print("The answer should be [[0,3],[5,0]]");
		}
	}


	public class Solution
	{
		public IList<IList<int>> GetSkyline(int[][] buildings)
		{
			List<IList<int>> list = new List<IList<int>>(buildings.Length)
			{ new List<int>() { buildings[0][0], buildings[0][2] } };

			int frontNow = buildings[0][0];
			int rearNow = buildings[0][1];
			int maxHeight = buildings[0][2];
			PriorityQueue<int[], int> pq = new();
			pq.Enqueue(new[] { rearNow, maxHeight }, -maxHeight);

			for (int i = 1; i <= buildings.Length; i++)
			{
				int from = (i == buildings.Length) ? int.MaxValue : buildings[i][0];
				int to = (i == buildings.Length) ? int.MaxValue : buildings[i][1];
				int height = (i == buildings.Length) ? 0 : buildings[i][2];
				if (height > maxHeight)
					if (from == frontNow)
					{
						list.RemoveAt(list.Count - 1);
					}
					else
					{
						frontNow = from;
					}

				if (from > rearNow || from == int.MaxValue)
				{
					// pop top
					while (pq.Count > 0 && pq.Peek()[0] <= rearNow && from > rearNow)
					{
						pq.Dequeue();
					}
					if (pq.Count > 0)
					{
						if (maxHeight != pq.Peek()[1])
							list.Add(new List<int>() { rearNow, pq.Peek()[1] });
						rearNow = pq.Peek()[0];
						maxHeight = pq.Peek()[1];
					}

					if (from > rearNow || from == int.MaxValue)
					{
						while (pq.Count > 0 && from > rearNow)
						{
							while (pq.Count > 0 && pq.Peek()[0] <= rearNow && from > rearNow)
							{
								pq.Dequeue();
							}
							if (pq.Count > 0)
							{
								if (maxHeight != pq.Peek()[1])
									list.Add(new List<int>() { rearNow, pq.Peek()[1] });
								rearNow = pq.Peek()[0];
								maxHeight = pq.Peek()[1];
							}
						}
						if (from > rearNow || from == int.MaxValue)
						{
							maxHeight = 0;
							list.Add(new List<int>() { rearNow, 0 });
						}
					}
				}

				if (i == buildings.Length)
					break;
				// add new then compare

				pq.Enqueue(new[] { to, height }, -height);

				if (height > maxHeight)
				{
					maxHeight = height;
					rearNow = pq.Peek()[0];
					list.Add(new List<int>() { from, height });
				}

				if (i == buildings.Length)
				{
					list.Add(new List<int>() { to, 0 });
				}
			}
			return list;
		}
	}
}