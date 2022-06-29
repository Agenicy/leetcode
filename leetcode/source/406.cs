using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Q406
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Console.WriteLine(Parser.Ans(solution.ReconstructQueue(Parser.Parse("[[2, 4],[3, 4],[9, 0],[0, 6],[7, 1],[6, 0],[7, 3],[2, 5],[1, 1],[8, 0]]"))));
			Console.WriteLine("The answer should be [[6,0],[1,1],[8,0],[7,1],[9,0],[2,4],[0,6],[2,5],[3,4],[7,3]]");
			Console.WriteLine(Parser.Ans(solution.ReconstructQueue(Parser.Parse("[[7,0],[4,4],[7,1],[5,0],[6,1],[5,2]]"))));
			Console.WriteLine("The answer should be [[5,0],[7,0],[5,2],[6,1],[4,4],[7,1]]");
			Console.WriteLine(Parser.Ans(solution.ReconstructQueue(Parser.Parse("[[6,0],[5,0],[4,0],[3,2],[2,2],[1,4]]"))));
			Console.WriteLine("The answer should be [[4,0],[5,0],[2,2],[3,2],[1,4],[6,0]]");
		}
	}

	public class Parser
	{
		public static int[][] Parse(string input)
		{
			//[[100,200],[200,1300],[1000,1250],[2000,3200]]
			List<int[]> ret = new List<int[]>();
			input = input.Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 2)
			{
				ret.Add(new int[] { int.Parse(array[i]), int.Parse(array[i + 1]) });
			}
			return ret.ToArray();
		}

		public static string Ans(int[][] input)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[");
			foreach (var item in input)
			{
				sb.Append($"[{item[0]},{item[1]}]");
			}
			sb.Append("]");
			return sb.ToString();
		}

	}

	public class Solution
	{
		public int[][] ReconstructQueue(int[][] people)
		{
			/* Constraints:
			 * 1 <= people.length <= 2000
			 * 0 <= hi <= 10^6
			 * 0 <= ki < people.length*/
			PriorityQueue<People, int> priorityQueue = new PriorityQueue<People, int>();
			foreach (var p in people)
			{
				priorityQueue.Enqueue(new People(p[0], p[1]), p[0] *2048 + p[1]);
			}
			List<int> orders = new List<int>(people.Length);
			for (int i = 0; i < people.Length; i++)
			{
				orders.Add(i);
			}
			int last = 0;
			int cnt = 0;
			while (priorityQueue.Count > 0)
			{
				var p = priorityQueue.Dequeue();
				int place;
				if (last == p.height)
				{
					place = p.order - (++cnt);
				}
				else
				{
					cnt = 0;
					last = p.height;
					place = p.order;
				}

				people[orders[place]] = p.Result();
				orders.RemoveAt(place);
			}

			return people;
		}

		class People
		{
			int[] Mem = new int[2];
			public int height => Mem[0];
			public int order => Mem[1];
			public People(int height, int order)
			{
				Mem = new int[2] { height, order };
			}

			public int[] Result() => Mem;
		}
	}
}