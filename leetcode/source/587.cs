using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q587
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.OuterTrees(Parser.ParseArr2D(" [[1,1],[2,2],[2,0],[2,4],[3,3],[4,2]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[][] OuterTrees(int[][] trees)
		{
			SortedList<int, int[]> points = new();
			foreach (var t in trees)
			{
				points.Add(t[0] * 1000 + t[1], t);
			}

			Stack<int> selectMin = new(), selectMax = new();
			float CalcM(int indA, int indB) => (float)(points.Values[indB][1] - points.Values[indA][1]) / (float)(points.Values[indB][0] - points.Values[indA][0]);

			Stack<float> ms = new();
			selectMin.Push(0);
			ms.Push(float.NegativeInfinity);
			for (int i = 1; i < points.Values.Count; i++)
			{
				float m = CalcM(selectMin.Peek(), i);
				while (m < ms.Peek())
				{
					ms.Pop();
					selectMin.Pop();
					m = CalcM(selectMin.Peek(), i);
				}
				selectMin.Push(i);
				ms.Push(m);
			}

			ms = new();
			selectMax.Push(0);
			ms.Push(float.PositiveInfinity);
			for (int i = 1; i < points.Values.Count; i++)
			{
				float m = CalcM(selectMax.Peek(), i);
				while (m > ms.Peek())
				{
					ms.Pop();
					selectMax.Pop();
					m = CalcM(selectMax.Peek(), i);
				}
				selectMax.Push(i);
				ms.Push(m);
			}

			HashSet<int[]> ret = new();
			foreach (var vs in selectMin)
			{
				ret.Add(points.Values[vs]);
			}
			foreach (var vs in selectMax)
			{
				ret.Add(points.Values[vs]);
			}
			return ret.ToArray();
		}
	}
}